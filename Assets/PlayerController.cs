using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //For Player Movement
    public float movementSpeed = 5f;
    public float jumpForce = 10f;
    //To check if grounded
    bool isGrounded;
    public Transform groundCheck;
    public float groundRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb2d;
    Animator anim;
    //INPUTS
    private float xInput;
    private bool jumpInput;
    private bool attackInput;

    //Checker
    bool isJumping = false;
	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GetInput();
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetInput();
        InitiatePlayerJump();
        PlayerAttack();
	}
    private void FixedUpdate()
    {
        PlayerMovement();
        if(isJumping)
        {
            PlayerJump();
        }
    }
    private void InitiatePlayerJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if(jumpInput && !isJumping && isGrounded)
        {
            isJumping = true;
        }
    }
    private void PlayerJump()
    {
        isJumping = false;
        rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    void GetInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        jumpInput = Input.GetKeyDown(KeyCode.Space);
        attackInput = Input.GetKeyDown(KeyCode.K);
    }
    void PlayerMovement()
    {
        rb2d.velocity = new Vector2(Mathf.Lerp(0, xInput * movementSpeed, 0.8f), rb2d.velocity.y);
    }
    void PlayerAttack()
    {
        if (attackInput)
        {
            anim.SetTrigger("Attack_1");
        }
    }
}
