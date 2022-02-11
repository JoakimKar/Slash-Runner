using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    GameSession gameSession;
    [SerializeField] int pointsForCoinPickup = 10;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            Destroy(gameObject);
        }
    }
}
