using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLifeGauge : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [HideInInspector]
    public int maxHealth;
    private int health;

	// Use this for initialization
	void Start ()
    {
        maxHealth = int.Parse(gameObject.GetComponent<BossController>().enemyModel.health.ToString());
	}
	// Update is called once per frame
	void Update ()
    {
	    health = int.Parse(gameObject.GetComponent<BossController>().enemyModel.health.ToString());
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            
            if(i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
