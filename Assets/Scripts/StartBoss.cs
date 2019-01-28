using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoss : MonoBehaviour
{
    BossController boss;
    GameManager gameManager;
    PlayerController player;
	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<PlayerController>();
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
        yield return new WaitForSeconds(1f);
    }
}
