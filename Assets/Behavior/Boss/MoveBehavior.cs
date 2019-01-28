using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehavior : StateMachineBehaviour
{
    private float timer;
    public float minTime;
    public float maxTime;

    public Vector2 minDistance;

    public float speed;

    private Rigidbody2D rb2d;

    private float randomWalkPattern; // for forward and backward movement
    private float randomAction;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        randomWalkPattern = Random.Range(0, 2);
        randomAction = Random.Range(0, 2);
        rb2d = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distanceBetweenMin = Vector2.Distance(minDistance, animator.transform.position);
        if (timer <= 0)
        {
            animator.SetBool("isIdle", true);
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if (randomWalkPattern == 0)
        {
            if (distanceBetweenMin <= 1f)
            {
                rb2d.velocity = Vector2.right * speed;
            }
            else
            {
                rb2d.velocity = Vector2.left * speed;
            }
        }
        else
        {
            rb2d.velocity = Vector2.right * speed;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
