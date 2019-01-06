using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed;

    private float orientation;
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
    public void Setup(float _orientation)
    {
        orientation = _orientation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Shoot();
        Destroy(gameObject, 2.5f);
	}
    void Shoot()
    {
        if (orientation == 1) //faces Left
        {
            rb2d.velocity = Vector2.left * speed;   
        }
        else //faces Right
        {
            rb2d.velocity = Vector2.right * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Playe been Hit");
        }
        Destroy(gameObject);
    }
}
