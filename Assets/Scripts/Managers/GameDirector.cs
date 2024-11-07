using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public EnemyManager enemyManager;
    public LevelManager levelManager;

    public Player player;
    private void Start()
    {
        RestartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        enemyManager.DeleteEnemies();
        levelManager.RestartLevelManager();
        enemyManager.GenerateEnemies();
        player.RestartPlayer();
    }

    public void PlayerReachedExit()
    {
        enemyManager.StopEnemies();
    }
}
