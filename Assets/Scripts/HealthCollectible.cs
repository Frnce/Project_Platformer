using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    LifeGauge playerLife;
    PlayerController player;
    public int lifeGain = 1;
	// Use this for initialization
	void Start ()
    {
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<LifeGauge>();
        player = FindObjectOfType<PlayerController>();
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!IsMaxHealth())
            {
                AddHealth();
            }
            //Play SE
            Destroy(gameObject);
        }
    }
    bool IsMaxHealth()
    {
        if (player.playerModel.health >= playerLife.maxHealth)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void AddHealth()
    {
        player.playerModel.health += lifeGain;
    }
}
