using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float spawnRate = 0.5f;
    private float spawnRateTimer = 0f;
   


    public Vector2 spawnLocVariance;

    public int enemiesToSpawn = 20;
    private int enemiesSpawned = 0;
    public bool spawning = true;

    public  GameObject [] EnemyPrefabs;
    private EnemyFish[] scriptTypes;
    private EnemyFish type;

    private void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(spawning)
        {
            spawnRateTimer += Time.deltaTime;

            if(spawnRateTimer > spawnRate)
            {
                SpawnEnemy();
                spawnRateTimer = 0;
            }
        }
    }

    void SpawnEnemy()
    {
        EnemyPrefabs[enemiesSpawned].transform.position = new Vector2(transform.position.x + Random.RandomRange(-spawnLocVariance.x, spawnLocVariance.x), transform.position.y +  Random.RandomRange(-spawnLocVariance.y, spawnLocVariance.y));
        EnemyPrefabs[enemiesSpawned].SetActive(true);
        EnemyPrefabs[enemiesSpawned].GetComponent<EnemyFish>().initValues();

        enemiesSpawned++;

        if(enemiesSpawned >= EnemyPrefabs.Length)
        {
            spawning = false;
        }
    }
}
