using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    public PlayerModel playerModel;
    //For Player Movement
    public float movementSpeed = 5f;
    public float jumpForce = 10f;
    public float jumpTime = 0.3f;
    private float jumpTimeCounter;
    //To check if grounded
    public Transform groundCheck;
    public float groundRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb2d;
    Animator anim;
    //INPUTS
    private float xInput;
    private bool attackInput;
    private bool jumpInputDown;
    private bool jumpInput;
    private bool jumpInputUp;

    //Checker
    bool isGrounded = false;
    bool isJumping = false;
    bool isMoving = false;
    bool isFalling = false;
    bool isFacingRight = true;

    bool canMove = true;
    [HideInInspector]
    public bool isAlive = true;

    float speedForce;

    //For Knockback
    public Vector2 knockBack;
    public float knockBackLength;
    [HideInInspector]
    public float knockBackCount;
    [HideInInspector]
    public bool knockFromRight;

    //For Player Attack Setting
    private float timeBetweenAttack;
    [Tooltip("startTimeBetweenAttack")]
    public float startTimeBetweenAttack;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        transform.position = gameManager.lastCheckPointPosition;

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GetInput();

        timeBetweenAttack = startTimeBetweenAttack;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        PlayerAttack();
        PlayerJump();
    }
    private void LateUpdate()
    {
        PlayerDeath();
    }
    private void FixedUpdate()
    {
        if (knockBackCount <= 0)
        {
            if (canMove)
            {
                if (gameManager.isInputValid())
                {
                    PlayerMovement();
                }
            }
            else
            {
                rb2d.velocity = Vector2.zero;
            }
        }
        else
        {
            if (knockFromRight)
            {
                rb2d.velocity = new Vector2(-knockBack.x, knockBack.y);
            }
            if (!knockFromRight)
            {
                rb2d.velocity = new Vector2(knockBack.x, knockBack.y);
            }

            knockBackCount -= Time.deltaTime;
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
    void GetInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        jumpInputDown = Input.GetKeyDown(KeyCode.Space);
        jumpInput = Input.GetKey(KeyCode.Space);
        jumpInputUp = Input.GetKeyUp(KeyCode.Space);

        attackInput = Input.GetKeyDown(KeyCode.K);

        SetAnimations();
    }
    void PlayerMovement()
    {
        //speedForce = isGrounded ? movementSpeed : movementSpeed * 0.6f; //try to make it more readable. its for reducing the air movement when after jumping .
                                                                        //speedForce = movementSpeed;
        if (xInput != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (xInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (xInput < 0 && isFacingRight)
        {
            Flip();
        }

        if (rb2d.velocity.y < -0.1)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }

        rb2d.velocity = new Vector2(Mathf.Lerp(0, xInput * movementSpeed, 0.8f), rb2d.velocity.y);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void PlayerAttack()
    {
        if (timeBetweenAttack <= 0)
        {
            if (attackInput)
            {
                StartCoroutine(IPlayerGroundAttack());
                timeBetweenAttack = startTimeBetweenAttack;
            }
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }
    IEnumerator IPlayerGroundAttack()
    {
        if (isGrounded)
        {
            canMove = false;
            anim.SetTrigger("Attack_1");

            yield return new WaitForSeconds(startTimeBetweenAttack);

            canMove = true;
        }
        else
        {
            anim.SetTrigger("Attack_1");

            yield return new WaitForSeconds(startTimeBetweenAttack);
        }
    }
    void SetAnimations()
    {
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isFalling", isFalling);
    }

    public void PlayerHit(float damage)
    {
        playerModel.health -= damage;
    }
    public void PlayerDeath()
    {
        if (playerModel.health <= 0)
        {
            isAlive = false;
            gameObject.SetActive(false);
        }
    }
    //On Moving platform behavior
    private void OnCollisionEnter2D(Collision2D collision) // For setting player when its on a moving platform
    {
        if (collision.transform.CompareTag("MovingPlatforms"))
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision) // For setting player when its OUT of the moving platform
    {
        if (collision.transform.CompareTag("MovingPlatforms"))
        {
            transform.parent = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}
