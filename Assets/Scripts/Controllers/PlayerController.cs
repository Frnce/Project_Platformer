using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerModel playerModel;
    //For Player Movement
    public float movementSpeed = 5f;
    public float jumpForce = 10f;
    public float jumpTime = 0.3f;
    private float jumpTimeCounter;
    //To check if grounded
    bool isGrounded;
    public Transform groundCheck;
    public float groundRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    Animator anim;
    //INPUTS
    private float xInput;
    private bool attackInput;
    private bool jumpInputDown;
    private bool jumpInput;
    private bool jumpInputUp;
    private bool crouchInput;

    //Checker
    bool isJumping = false;
    bool isMoving = false;
    bool isCrouching = false;
	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        GetInput();
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetInput();

        spriteRenderer.flipX = rb2d.velocity.x < 0 ? true : false;

        PlayerAttack();
        PlayerJump();
        PlayerCrouch();
    }
    private void FixedUpdate()
    {
       if(!isCrouching)
        {
            PlayerMovement();
        }
    }
    private void PlayerJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (jumpInputDown && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb2d.velocity = Vector2.up * jumpForce;
        }
        if (jumpInput && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb2d.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (jumpInputUp)
        {
            isJumping = false;
        }
    }
    private void PlayerCrouch()
    {
        if (crouchInput)
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }
    }
    void GetInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        jumpInputDown = Input.GetKeyDown(KeyCode.Space);
        jumpInput = Input.GetKey(KeyCode.Space);
        jumpInputUp = Input.GetKeyUp(KeyCode.Space);

        attackInput = Input.GetKeyDown(KeyCode.K);

        crouchInput = Input.GetKey(KeyCode.S);

        SetAnimations();
    }
    void PlayerMovement()
    {
        if(xInput != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        rb2d.velocity = new Vector2(Mathf.Lerp(0, xInput * movementSpeed, 0.8f), rb2d.velocity.y);
    }
    void PlayerAttack()
    {
        if (attackInput)
        {
            anim.SetTrigger("Attack_1");
        }
    }
    void SetAnimations()
    {
        anim.SetFloat("xMove", xInput);
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isCrouching", isCrouching);
    }

    public void PlayerHit(float damage)
    {
        playerModel.health -= damage;
    }
    public void PlayerDeath()
    {

    }
}
