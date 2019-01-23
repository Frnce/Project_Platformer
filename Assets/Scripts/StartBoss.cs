using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoss : MonoBehaviour
{
    BossController boss;
	// Use this for initialization
	void Start ()
    {
        boss = FindObjectOfType<BossController>();
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boss.StartBossBattle();
            GetComponent<BoxCollider2D>().enabled = false;
            //Use Coroutine
            //on boss animation , temporarily disable player controls
            //Show Boss HP UI
        }
    }
}
