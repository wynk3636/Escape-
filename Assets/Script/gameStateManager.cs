using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStateManager : MonoBehaviour
{

    public static bool gameState;
    public GameObject gamePanel;
    public string gameOverObject = "GameOverPanel";

    void Start()
    {
        Time.timeScale = 1.0f;
        gameState = true;
        gamePanel = GameObject.Find(gameOverObject);
        gamePanel.SetActive(false);
    }

    void Update()
    {

        if (gameState==false)
        {
            gamePanel.SetActive(true);

            //moveFloor._speed = 0;
            Time.timeScale = 0.0f;
        }
    }
}
