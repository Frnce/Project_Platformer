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
