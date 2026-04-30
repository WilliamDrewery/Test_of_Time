using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnManager : MonoBehaviour
{
    //[SerializeField] Vector3 spawnPos;
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] int enemiesMaxInScene;
    [SerializeField] int enemiesInWave;
    public int enemiesAlive;
    public int enemiesSpawnedIn;
    [SerializeField] float amountToStopSpawning;
    [SerializeField] int enemiesKilled;
    [SerializeField] int round;
    [SerializeField] bool paused;
    public bool roundOver;
    [SerializeField] float spawnInterval;
    public float roundTimer;
    [SerializeField] float roundTimerOriginal;
    public int currentRound;
    [SerializeField] GameObject shopTrigger;
    [SerializeField] UI uiManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
        roundTimer = roundTimerOriginal;
        shopTrigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesKilled == enemiesInWave - 2)
        {
            paused = true;
        }

        round = currentRound;
        if (roundOver && !uiManager.shopDisplayActive)
        {
            roundTimer -= Time.deltaTime;
            shopTrigger.SetActive(true);
            if (roundTimer <= 0)
            {
                shopTrigger.SetActive(false);
                StartCoroutine(Spawner());
                roundTimer = roundTimerOriginal;
                roundOver = false;
            }

            

        }

        if (roundOver && uiManager.shopDisplayActive) 
        {
            roundTimer = roundTimer;
        }
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            
            if (enemiesAlive < enemiesMaxInScene && !paused)
            {
                SpawnEnemy();
                ++enemiesAlive;
                yield return new WaitForSeconds(spawnInterval);
            }

            else
            {
                yield return null;
            }

            if(enemiesKilled == enemiesInWave)
            {
                NewRound();
                break; 
            }
        }
    }

    public void SpawnEnemy()
    {
        int spawnPoint = Random.Range(0, spawnPoints.Length);
        int enemySpawn = Random.Range(1, 11);
        if (enemySpawn > 5)
        {
            Instantiate(enemyPrefab[1], spawnPoints[spawnPoint].position, Quaternion.identity);
        }

        else
        {
            Instantiate(enemyPrefab[0], spawnPoints[spawnPoint].position, Quaternion.identity);
        }
        Debug.Log(enemySpawn);
    }

    public void ReduceCounter()
    {
        enemiesKilled++;
    }

    public void NewRound()
    {
        paused = false;
        enemiesKilled = 0;
        currentRound++;
        enemiesInWave += 1;
        roundOver = true;
        foreach (var enemy in enemyPrefab)
            {
                if (enemy.GetComponent<Enemy>())
                {
                    Enemy enemyStats = enemy.GetComponent<Enemy>();
                    enemyStats.Health += 1;
                    Debug.Log("ABC");
                }
            }
        
        
        Debug.Log("round ended");
    }
}
