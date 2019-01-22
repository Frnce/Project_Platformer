using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyModel enemyModel;
    public float movementSpeed = 5f;
    public bool IsDead()
    {
        if (enemyModel.health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void EnemyHit(float damage)
    {
        //This is where you put all the special effect when hit\
        enemyModel.health -= damage;
        Debug.Log("Enemy has been Hit");
    }
}
