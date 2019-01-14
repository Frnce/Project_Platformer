using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyModel enemyModel;
    public float movementSpeed = 5f;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (enemyModel.health <= 0)
        {
            //Play animation first before destroying the object
            Destroy(gameObject);
        }
    }

    public void EnemyHit(float damage)
    {
        //This is where you put all the special effect when hit\
        enemyModel.health -= damage;
        Debug.Log("Enemy has been Hit");
    }
}
