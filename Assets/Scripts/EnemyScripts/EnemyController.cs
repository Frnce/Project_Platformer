using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movementSpeed = 5f;

    public EnemyModel enemyModel;

    [HideInInspector]
    public PlayerController player;

	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (enemyModel.Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //Enemy Attack
            //Damage player
            Debug.Log("PlayerHit");
        }
    }

    public void EnemyHit(float damage)
    {
        //This is where you put all the special effect when hit\
        enemyModel.Health -= damage;
        Debug.Log("Enemy has been Hit");
    }
    
}
