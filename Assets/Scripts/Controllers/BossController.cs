using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public EnemyModel enemyModel;
    public GameObject healthBar;
    private bool isStarted = false;

    public AudioClip hurtSound;

    Animator anim;
    PlayerController player;

    [HideInInspector]
    public bool isDead = false;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        CheckIsDead();
        LookAtPlayer();
    }
    public void EnemyHit(float damage)
    {
        //This is where you put all the special effect when hit\
        SoundManager.instance.PlaySingle(hurtSound);
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
            anim.SetBool("isDead", isDead);
        }
    }
    void LookAtPlayer()
    {
        Vector3 theScale = transform.localScale;
        if (player.transform.position.x > transform.position.x)
        {
            theScale.x = 1;
        }
        else
        {
            theScale.x = -1;
        }
        transform.localScale = theScale;
    }
}
