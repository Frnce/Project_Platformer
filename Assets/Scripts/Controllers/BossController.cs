using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public EnemyModel enemyModel;
    public GameObject healthBar;
    private bool isStarted = false;
    Animator anim;

    private bool isDead = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void Update()
    {
        CheckIsDead();
    }
    public void EnemyHit(float damage)
    {
        //This is where you put all the special effect when hit\
        enemyModel.health -= damage;
        Debug.Log("Enemy has been Hit");
    }
    public void StartBossBattle()
    {
        isStarted = true;
        anim.SetBool("isStarted", isStarted);
        healthBar.SetActive(true);
    }

    void CheckIsDead()
    {
        if(enemyModel.health <= 0)
        {
            isDead = true;
        }
    }
}
