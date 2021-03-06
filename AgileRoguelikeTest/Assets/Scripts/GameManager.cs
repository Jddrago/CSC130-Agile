﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float turnDelay = 0.1f;
    public static GameManager instance = null;
    public BoardManager boardScript;
    [HideInInspector] public bool playersTurn = true;
    public static int level = 1;
    private static List<Enemy> enemies;
    private bool enemiesMoving;
    public Text DeathText;


	// Use this for initialization
	void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        enemies = new List<Enemy>();
        boardScript = GetComponent<BoardManager>();
        InitGame();
	}
    void InitGame()
    {
        enemies.Clear();
        boardScript.SetupScene(level);

    }
    public void GameOver()
    {
        DeathText.enabled = true;
        enabled = false;
    }

	// Update is called once per frame
	void Update ()
    {
        if (playersTurn || enemiesMoving) return;

        StartCoroutine(MoveEnemies());
	}

    public void AddEnemyToList(Enemy script)
    {
        enemies.Add(script);
    }

    IEnumerator MoveEnemies()
    {
        enemiesMoving = true;
        yield return new WaitForSeconds(turnDelay);
        if (enemies.Count == 0)
        {
            yield return new WaitForSeconds(turnDelay);
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].MoveEnemy();
            yield return new WaitForSeconds(enemies[i].moveTime);
        }

        playersTurn = true;
        enemiesMoving = false;
    }

    void Start()
    {
        //level++;
        //Debug.Log("");
        SceneManager.sceneLoaded += delegate (Scene scene, LoadSceneMode mode)
        {
            level++;
        };
    }
}
