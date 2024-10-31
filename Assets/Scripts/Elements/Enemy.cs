using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;

    public float speed;

    void Update()
    {
        Vector3 direction = Vector3.zero;
        if (player.isAppleCollected)
        {
            direction = (player.transform.position - transform.position).normalized;
            direction.y = 0;
        }
        transform.position += direction * speed * Time.deltaTime;
    }
}
