using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoss : MonoBehaviour
{
    BossController boss;
    GameManager gameManager;
	// Use this for initialization
	void Start ()
    {
        gameManager = FindObjectOfType<GameManager>();
        boss = FindObjectOfType<BossController>();
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(BossCoroutine());
        }
    }

    IEnumerator BossCoroutine()
    {
        boss.StartBossBattle();
        GetComponent<BoxCollider2D>().enabled = false;
        gameManager.acceptUserInput = false;
        yield return new WaitForSeconds(1f);
        gameManager.acceptUserInput = true;
    }
}
