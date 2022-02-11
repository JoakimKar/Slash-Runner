using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRB;

    void Start()
    {
       myRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRB.velocity = new Vector2 (moveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        moveSpeed = -moveSpeed;   
        FlipEnemyFacing();
    }

    private void FlipEnemyFacing()
    {
        transform.localScale = new Vector2 (-(Mathf.Sign(myRB.velocity.x)), 1f);
    }
}
