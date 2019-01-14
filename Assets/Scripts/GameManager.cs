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
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckIfPlayerIsDead();
        RestartScene();
	}

    private void CheckIfPlayerIsDead()
    {
        if (!player.isAlive)
        {
            Debug.Log("Player Dead, Please Restart Stage");
            Time.timeScale = 0f;
            // show restart round UI
        }
    }

    private void RestartScene()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
