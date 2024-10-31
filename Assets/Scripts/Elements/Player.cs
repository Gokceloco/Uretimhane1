using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header ("Properties")]
    public float playerMoveSpeed;
    public bool canChangeDirectionWhileJumping;
    public float jumpPower;

    private Rigidbody _rb; 
    private bool _isPlayerTouchingGround;
    private bool _isAppleCollected;
    private bool _isGameStarted;
    public void StartPlayer()
    {
        _rb = GetComponent<Rigidbody>();
        _isGameStarted = true;
    }

    void Update()
    {
        if (!_isGameStarted)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isPlayerTouchingGround)
        {
            _isPlayerTouchingGround = false;
            JumpPlayer();
        }
        MovePlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isPlayerTouchingGround = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isPlayerTouchingGround = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Collectable"))
        {
            _isAppleCollected = true;
            other.gameObject.SetActive(false);
        }
    }

    private void JumpPlayer()
    {
        _rb.AddForce(Vector3.up * jumpPower);
    }
    void MovePlayer()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }

        if (canChangeDirectionWhileJumping)
        {
            _rb.position += direction.normalized * playerMoveSpeed * Time.deltaTime;
        }
        else if (_isPlayerTouchingGround)
        {
            _rb.velocity = direction.normalized * playerMoveSpeed;
        }
    }
    public bool GetIfAppleCollected()
    {
        return _isAppleCollected;
    }

    
}
