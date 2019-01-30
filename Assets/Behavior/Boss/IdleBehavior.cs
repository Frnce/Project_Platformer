using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : StateMachineBehaviour
{
    private float timer;
    public float minTime;
    public float maxTime;

    private float randomAction;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randomAction = Random.Range(0, 4);
        timer = Random.Range(minTime, maxTime);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if(randomAction == 0)
            {
                animator.SetTrigger("Jump");
            }
            if(randomAction == 1)
            {
                animator.SetTrigger("Move");
            }
            if(randomAction == 2)
            {
                animator.SetTrigger("attack1");
            }
            if(randomAction == 3)
            {
                animator.SetTrigger("attack2");
            }
            if(randomAction == 4)
            {
                animator.SetTrigger("attack3");
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
