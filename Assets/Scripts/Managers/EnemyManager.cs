using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public void GenerateEnemies()
    {
        for (int i = 0; i < 5; i++)
        {
            var newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector3(i - 2, .5f, UnityEngine.Random.Range(-3f, 3f));
            newEnemy.player = player;

            newEnemy.transform.localScale = Vector3.zero;
            newEnemy.transform.DOScale(new Vector3(.6f,1f,.6f), .2f).SetEase(Ease.OutBack);

            var targetZPos = 2.5f;
            var distance = 0f;

            if (newEnemy.transform.position.z < 0)
            {
                distance = targetZPos - newEnemy.transform.position.z;
                newEnemy.transform.DOMoveZ(targetZPos, 2f)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Yoyo);
            }
            else
            {
                targetZPos = -2.5f;
                distance = targetZPos - newEnemy.transform.position.z;
                newEnemy.transform.DOMoveZ(targetZPos, 2f)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Yoyo);
            }

            enemies.Add(newEnemy);
        }     
    }
    public void KillEnemyTweens()
    {
        foreach (var e in enemies)
        {
            e.transform.DOKill();
        }
    }
}
