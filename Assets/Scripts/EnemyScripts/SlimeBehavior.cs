using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehavior : EnemyController
{
    private Animator anim;
    //private Rigidbody2D rb2d;
    public Transform[] points = null;
    private Transform currentPoint;
    //private int pointSelection = 0;

    //private bool isMoving = false;
    private bool isFacingRight = false;
 	// Use this for initialization
	void Start ()
    {
        //rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //currentPoint = points[pointSelection];
        SetAnimations();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //transform.position = Vector2.MoveTowards(transform.position, currentPoint.position, Time.deltaTime * movementSpeed);

        //if(transform.position == currentPoint.position)
        //{
        //    pointSelection++;
        //    if(pointSelection == points.Length)
        //    {
        //        pointSelection = 0;
        //    }
        //    currentPoint = points[pointSelection];
        //}

        if (IsDead())
        {
            StartCoroutine(DeadRoutine());
        }
	}

    IEnumerator DeadRoutine()
    {
        anim.SetBool("isDead", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    void SetAnimations()
    {
        anim.SetBool("isDead", false);
        anim.SetBool("isMoving", false);
    }
    void SlimeMove()
    {
        anim.SetBool("isMoving", true);
        //HERE YOU SET THE MOVEMENT 
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
