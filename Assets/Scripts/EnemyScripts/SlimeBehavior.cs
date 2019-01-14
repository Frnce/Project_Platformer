using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehavior : EnemyController
{
    //private Animator anim;
    //private Rigidbody2D rb2d;
    public Transform[] points = null;
    private Transform currentPoint;
    private int pointSelection = 0;

 	// Use this for initialization
	void Start ()
    {
        //rb2d = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        currentPoint = points[pointSelection];
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentPoint.position, Time.deltaTime * movementSpeed);

        if(transform.position == currentPoint.position)
        {
            pointSelection++;
            if(pointSelection == points.Length)
            {
                pointSelection = 0;
            }
            currentPoint = points[pointSelection];
        }
	}
}
