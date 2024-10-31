using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public Player player;
    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        player.StartPlayer();
    }
}
