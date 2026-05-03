using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnManager : MonoBehaviour
{
    //[SerializeField] Vector3 spawnPos;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float spawnInterval;

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
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
                
        }
    }

    public void SpawnEnemy()
    {
        int spawnPoint = Random.Range(0, spawnPoints.Length);

        Instantiate(enemyPrefab, spawnPoints[spawnPoint].position, Quaternion.identity);

    }

}
