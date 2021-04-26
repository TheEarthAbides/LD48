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

    public Transform[] waypoints;

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
        EnemyPrefabs[enemiesSpawned].transform.position = new Vector2(transform.position.x + Random.Range(-spawnLocVariance.x, spawnLocVariance.x), transform.position.y +  Random.Range(-spawnLocVariance.y, spawnLocVariance.y));
        EnemyPrefabs[enemiesSpawned].GetComponent<EnemyFish>().initValues(waypoints);

        EnemyPrefabs[enemiesSpawned].SetActive(true);

        enemiesSpawned++;

        if(enemiesSpawned >= enemiesToSpawn)
        {
            spawning = false;
            enemiesSpawned = 0;
            gameObject.SetActive(false);
            GameManager.instance.SpawnerDeactivated();
        }

        
    }

    public void OnEnable()
    {
        spawning = true;
    }
}
