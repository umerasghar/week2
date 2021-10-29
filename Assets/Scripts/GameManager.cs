using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject playerMain, enemyMain;
    public GameObject enemySpawn;
    public Canvas mainCanvas;
    public float levelProgress=0.2f;
    public Image progressBar;
    public Text scoreText;
    public float playerScore;
    public static  bool enemyKilled;
    public static bool canThrow;
    private void Awake()
    {
            instance = this;
       
    }
    // Start is called before the first frame update
    void Start()
    {
        EventTriggers.onEnemyDead += UpdateUI;
    }
    private void OnDisable()
    {
        EventTriggers.onEnemyDead -= UpdateUI;
    }
    public void UpdateUI()
    {
        levelProgress += 0.2f;
        progressBar.fillAmount = levelProgress;
        playerScore += 5;
        scoreText.text = playerScore+"";
        SpawnEnemy();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyMain);
        enemy.transform.parent = mainCanvas.transform;
        enemy.transform.position = enemySpawn.transform.position;
        enemy.transform.localScale = new Vector3(1f, 1f, 1f);
        enemyKilled = false;

    }

}
