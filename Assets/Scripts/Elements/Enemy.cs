using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;
    public float speed;

    private void Update()
    {
        if (player.GetIfAppleCollected())
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        var direction = (player.transform.position - transform.position).normalized;
        direction.y = 0;
        transform.position += direction * Time.deltaTime * speed;
    }
}
