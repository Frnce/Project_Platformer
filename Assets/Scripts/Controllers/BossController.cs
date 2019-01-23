using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public EnemyModel enemyModel;
    public GameObject healthBar;
    private bool isStarted = false;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void Update()
    {
       
    }

    public void StartBossBattle()
    {
        isStarted = true;
        anim.SetBool("isStarted", isStarted);
        healthBar.SetActive(true);
    }
}
