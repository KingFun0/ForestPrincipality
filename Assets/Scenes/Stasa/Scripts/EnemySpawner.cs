using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyGO;

     public float maxSpawnRateInSeconds = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke ("SpawnEnemy", maxSpawnRateInSeconds);

        InvokeRepeating("IncreaseSpawnRate", 0f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0 ));
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1 ));

        GameObject anEnemy = (GameObject)Instantiate (EnemyGO);
        anEnemy.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

        SheduleNextEnemySpawn ();

    }
    void SheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        if(maxSpawnRateInSeconds >1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInNSeconds = 1f;

            Invoke("SpawnEnemy", spawnInNSeconds);
    }

    void IncreaseSpawnRate()
    {
        if(maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;
        if(maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");

    }
}
