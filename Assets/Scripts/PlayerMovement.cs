using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRB;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask Enemies;
    public Animator myAnimator;

    float moveInput;
    private bool isFacingRight = true;
    private bool vertical;
    [Header("Player Settings")]
    [SerializeField] float runSpeed = 8f;
    [SerializeField] float jumpingPower = 16f;

    float activeMoveSpeed;
    [Header("Dash Settings")]
    [SerializeField] float dashSpeed;
    [SerializeField] float dashLenght;
    [SerializeField] float dashCooldown;

    float dashCounter;
    float dashcoolCounter;

    bool isAlive = true;

    BoxCollider2D myBoxCollider;


    //[SerializeField] ParticleSystem dashParticles;




    void Start() 
    {   
        activeMoveSpeed = runSpeed;
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (!isAlive) { return; }
        FlipSprite();
        Jump();
        Dash();
        Die();
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashcoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLenght;
                //dashParticles.Play();
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = runSpeed;
                dashcoolCounter = dashCooldown;
            }
        }

        if (dashcoolCounter > 0)
        {
            dashcoolCounter -= Time.deltaTime;
        }
    }

    private void FlipSprite()
    {
        if (!isFacingRight && moveInput > 0f)
        {
            Flip();
        }
        else if (isFacingRight && moveInput < 0f)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }


    private void Jump()
    {
        if(!isAlive) { return; }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            myRB.velocity = new Vector2(myRB.velocity.x, jumpingPower);
        }

        if (Input.GetKeyUp(KeyCode.Space) && myRB.velocity.y > 0f)
        {
            myRB.velocity = new Vector2(myRB.velocity.x, myRB.velocity.y * 0.5f);
        }
    }

    void FixedUpdate()
    {
        if (!isAlive) { return; }
        moveInput = Input.GetAxisRaw("Horizontal");
        myRB.velocity = new Vector2(moveInput * activeMoveSpeed, myRB.velocity.y);
        myAnimator.SetFloat("isRunning", Mathf.Abs(moveInput));
        JumpAnim();
    }

    private void JumpAnim()
    {
        if (!IsGrounded())
        {
            myAnimator.SetBool("isJumping", true);
        }
        else
        {
            myAnimator.SetBool("isJumping", false);
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Die()
    {
        if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {
            isAlive = false;
            myAnimator.SetBool("isJumping", false);
            myAnimator.SetBool("isIdle", false);
            myAnimator.SetBool("IsDeath", true);
            myRB.velocity = new Vector2 (0,0f);
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
