using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HitPlayerByEnemy : MonoBehaviour
{
    private float damage;
    [HideInInspector]
    public PlayerController player;
    [HideInInspector]
    public EnemyController enemy;

    public float maxHitCooldown = 0.5f;
    private float hitCooldown;
    bool isHit = false;

    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<PlayerController>();
        enemy = GetComponent<EnemyController>();

        damage = enemy.enemyModel.damage;

        hitCooldown = maxHitCooldown;
    }
    private void Update()
    {
        if (isHit)
        {
            hitCooldown -= Time.deltaTime;
            if(hitCooldown <= 0)
            {
                isHit = false;
                hitCooldown = maxHitCooldown;
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
