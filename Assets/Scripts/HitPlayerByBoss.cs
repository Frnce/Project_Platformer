using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayerByBoss : MonoBehaviour
{
    private float damage;
    [HideInInspector]
    public PlayerController player;
    [HideInInspector]
    public BossController boss;
    public float maxHitCooldown = 0.5f;
    private float hitCooldown;
    bool isHit = false;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        boss = FindObjectOfType<BossController>();
        damage = boss.enemyModel.damage;
        hitCooldown = maxHitCooldown;
    }
    private void Update()
    {
        if (isHit)
        {
            hitCooldown -= Time.deltaTime;
            if (hitCooldown <= 0)
            {
                isHit = false;
                hitCooldown = maxHitCooldown;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.knockBackCount = player.knockBackLength;
            if (collision.transform.position.x < transform.position.x)
            {
                player.knockFromRight = true;
            }
            else
            {
                player.knockFromRight = false;
            }

            if (!isHit)
            {
                player.PlayerHit(damage);
                isHit = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.knockBackCount = player.knockBackLength;
            if (collision.transform.position.x < transform.position.x)
            {
                player.knockFromRight = true;
            }
            else
            {
                player.knockFromRight = false;
            }

            if (!isHit)
            {
                player.PlayerHit(damage);
                isHit = true;
            }
        }
    }
}
