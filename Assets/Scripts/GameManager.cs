using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasReachedEnd = false;

    public GameObject endLevelUI;

    public GameObject deathUI;

    public GameObject pauseUI;

    public PlayerMovement playerMovement;

    public static bool GameIsPaused = false;

    TimerCounter timeCounter;

    void Start() 
    {
        TimerCounter.instance.BeginTimer();
        Time.timeScale = 1;
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
       pauseUI.SetActive(true);
       Time.timeScale = 0f;
       GameIsPaused = true;
    }

    public void Nextlevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    public void CompleteLevel ()
    {
        TimerCounter.instance.EndTimer();
        gameHasReachedEnd = true;
        endLevelUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        if (gameHasReachedEnd == false)
        {
            gameHasReachedEnd = true;
            Debug.Log("dead");
            deathUI.SetActive(true);
            TimerCounter.instance.EndTimer();
            Time.timeScale = 0;
        }
    }

    public void Restart ()
    {
        Time.timeScale = 1;
        TimerCounter.instance.EndTimer();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        TimerCounter.instance.BeginTimer();
        GameIsPaused = false;
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene(0);
    }
}
