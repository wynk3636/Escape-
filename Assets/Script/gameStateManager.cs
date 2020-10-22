using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStateManager : MonoBehaviour
{

    public static bool gameState = true;
    public string gameOverObject = "GameOverPanel";
    GameObject gameObject;

    void Start()
    {
        gameObject = GameObject.Find(gameOverObject);
        gameObject.SetActive(false);
    }

    void Update()
    {

        if (gameState==false)
        {
            gameObject.SetActive(true);

            moveFloor._speed = 0;
            Time.timeScale = 0.0f;
        }
    }
}
