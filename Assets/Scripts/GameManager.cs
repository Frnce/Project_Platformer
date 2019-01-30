using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public Vector2 lastCheckPointPosition;
    PlayerController player;
    BossController boss;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<PlayerController>();
        boss = FindObjectOfType<BossController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckIfPlayerIsDead();
        if (!player.isAlive)
        {
            RestartScene();
        }
	}

    private void CheckIfPlayerIsDead()
    {
        if (!player.isAlive)
        {
            Debug.Log("Player Dead, Press BackSpace to Restart Stage");
            // show restart round UI
        }
    }
    void CheckIfGameOver()
    {
        if (boss.isDead)
        {
            Debug.Log("Game Over. .  Thanks for Playing. Press BackSpace to Restart Game");
            lastCheckPointPosition = new Vector2(0, 0.5075328f);
        }
    }

    private void RestartScene()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("GreyBox");
        }
    }
}
