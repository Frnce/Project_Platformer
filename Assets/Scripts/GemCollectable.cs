﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollectable : MonoBehaviour
{
    public int point = 5;
    CollectedGems collectedGems;
    private void Start()
    {
        collectedGems = FindObjectOfType<CollectedGems>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Point Added : " + point);
            collectedGems.AddPoints(point);
            // play sound effect;
            Destroy(gameObject);
        }
    }
}
