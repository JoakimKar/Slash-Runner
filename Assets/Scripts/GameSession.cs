using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    public static GameSession instance;

    [SerializeField] int score = 0;

    [SerializeField] TextMeshProUGUI scoreText;

    public GameManager gameManager;

    TimerCounter timeCounter;


    void Start() 
    {
        scoreText.text = score.ToString();
        TimerCounter.instance.BeginTimer();
        scoreText.text = "Score: 0";
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "Score: " + score.ToString();
    }

    

    private void ResetGameSession()
    {
        gameManager.Restart();
        Destroy(gameObject);
    }


}
