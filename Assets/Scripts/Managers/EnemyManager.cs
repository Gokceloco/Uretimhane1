using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Player player;
    public Enemy enemyPrefab;
    public List<Enemy> enemies;
    public void StopEnemies()
    {
        foreach (var e in enemies)
        {
            e.speed = 0;
        }
    }
    public void DeleteEnemies()
    {
        var tempList = new List<Enemy>(enemies);
        foreach (var e in tempList)
        {
            enemies.Remove(e);
            Destroy(e.gameObject);
        }
    }
    public void GenEnemies()
    {
        for (int i = 0; i < 5; i++)
        {
            var newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector3(i - 2, .5f, UnityEngine.Random.Range(-3f, 3f));
            newEnemy.player = player;
            enemies.Add(newEnemy);
        }        
    }
}
