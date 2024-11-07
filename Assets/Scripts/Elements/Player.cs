using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;

    [Header ("Properties")]
    public float playerMoveSpeed;
    public bool canChangeDirectionWhileJumping;
    public float jumpPower;

    private Rigidbody _rb; 
    private bool _isPlayerTouchingGround;
    private bool _didPlayerMakeTheSecondJump;
    private bool _isAppleCollected;
    private bool _isGameStarted;

    public int maxJumpCount;

    private int jumpCount;
    public void RestartPlayer()
    {
        _rb = GetComponent<Rigidbody>();
        _isGameStarted = true;

        transform.position = new Vector3(-3.5f, .5f, 0);
        _rb.velocity = Vector3.zero;
        gameObject.SetActive(true);
        _isAppleCollected = false;
    }

    void Update()
    {
        if (!_isGameStarted)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) 
            && (_isPlayerTouchingGround || jumpCount < maxJumpCount))
        {
            _isPlayerTouchingGround = false;
            jumpCount += 1;
            JumpPlayer();
        }
        MovePlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isPlayerTouchingGround = true;
            jumpCount = 0;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            gameDirector.enemyManager.StopEnemies();
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
        if (other.CompareTag("Apple"))
        {
            _isAppleCollected = true;
            other.gameObject.SetActive(false);
            maxJumpCount += 1;
            gameDirector.levelManager.exit.gameObject.SetActive(true);
            gameDirector.enemyManager.KillEnemyTweens();
        }
        if (other.CompareTag("Exit") && _isAppleCollected)
        {
            gameDirector.PlayerReachedExit();
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
