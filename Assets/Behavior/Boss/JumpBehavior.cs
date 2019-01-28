using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehavior : StateMachineBehaviour {

    Rigidbody2D rb2d;

    public float jumpForce;
    public float maxJumpTime;
    private float jumpTime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb2d = animator.GetComponent<Rigidbody2D>();
        jumpTime = maxJumpTime;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        while (jumpTime > 0)
        {
            jumpTime -= Time.deltaTime;
            if(jumpTime <= 0)
            {
                jumpTime = maxJumpTime;
                animator.SetBool("isIdle", true);
                break;
            }
            else
            {
                rb2d.velocity = Vector2.up * jumpForce;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
