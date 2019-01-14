using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : EnemyController
{
    private PlayerController player;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void FixedUpdate()
    {
        EnemyMove();
    }
    void EnemyMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
    }
}
