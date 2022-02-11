using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other) 
    {
        gameManager.CompleteLevel();
    }
}
