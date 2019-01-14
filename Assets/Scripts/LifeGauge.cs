using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeGauge : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite EmptyHeart;

    private void Start()
    {
        maxHealth = int.Parse(gameObject.GetComponent<PlayerController>().playerModel.health.ToString());
    }
    private void Update()
    {
        health = int.Parse(gameObject.GetComponent<PlayerController>().playerModel.health.ToString());
        if (health > maxHealth)
        {
            health = maxHealth; 
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i  < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
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
