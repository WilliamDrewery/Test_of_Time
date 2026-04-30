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



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
       

    }

    // Update is called once per frame
    void Update()
    {
        
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
                
                break; 
            }
        }
    }

    public void SpawnEnemy()
    {
        int spawnPoint = Random.Range(0, spawnPoints.Length);
        int enemySpawn = Random.Range(1, 11);
        
        
            Instantiate(enemyPrefab[0], spawnPoints[spawnPoint].position, Quaternion.identity);
        
        Debug.Log(enemySpawn);
    }

   
}
