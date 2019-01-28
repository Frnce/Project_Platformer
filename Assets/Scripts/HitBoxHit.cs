using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxHit : MonoBehaviour
{
    private PlayerController player;
    public Vector2 knockBack;
    public float knockBackLength;
    [HideInInspector]
    public float knockBackCount;
    [HideInInspector]
    public bool knockFromRight;
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
        else if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossController>().EnemyHit(player.playerModel.attack);
        }
    }
}
