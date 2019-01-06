using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : EnemyController
{
    public GameObject projectile;
    public Transform projectileSpawner;

    private float fireRate;
    public float maxFireRate;
	// Use this for initialization
	void Start ()
    {
        fireRate = maxFireRate;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (fireRate <= 0)
        {
            ProjectileScript projectileScript = Instantiate(projectile, projectileSpawner.position, Quaternion.identity).GetComponent<ProjectileScript>();
            projectileScript.Setup(gameObject.transform.localScale.x);

            fireRate = maxFireRate;
        }
        else
        {
            fireRate -= Time.deltaTime;
        }
	}

}
