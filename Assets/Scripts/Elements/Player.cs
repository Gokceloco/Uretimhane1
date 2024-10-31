using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerMoveSpeed;

    //public float tempSpeed;

    public Rigidbody rb;

    public float jumpPower;

    public bool isPlayerTouchingGround;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerTouchingGround)
        {
            isPlayerTouchingGround = false;
            JumpPlayer();
        }
        MovePlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isPlayerTouchingGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isPlayerTouchingGround = false;
        }
    }

    private void JumpPlayer()
    {
        rb.AddForce(Vector3.up * jumpPower);
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
        if (isPlayerTouchingGround)
        {
            rb.velocity = direction.normalized * playerMoveSpeed;
        }
        //rb.position += direction.normalized * playerMoveSpeed * Time.deltaTime;

        //transform.position += direction.normalized * playerMoveSpeed * Time.deltaTime;
    }
}
