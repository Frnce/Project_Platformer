using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxHit : MonoBehaviour
{
    private PlayerController player;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyController>().EnemyHit(player.playerModel.attack);
        }
    }
}
