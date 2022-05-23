using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField] Transform[] spawnLocation;
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject cubes;
    int spawnPointsCount=1;
    void Start()
    {
      levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        SpawnCubes();
        DefineSpawnCount();
    }
    void SpawnCubes()
    {
        int spawnCount = 0;
        if (!levelManager.pauseGame)
        {
            for (int i = 0; i < spawnPointsCount; i++)
            {
                spawnCount++;
                if (spawnTimer <= 0)
                {
                    int index = Random.Range(0, spawnLocation.Length);
                    Instantiate(cubes, spawnLocation[index].position, Quaternion.identity);
                    spawnCount++;
                    if (spawnCount >= spawnPointsCount)
                    {
                        SetSpawnTimer();
                        spawnCount = 0;
                    }
                }

            }
        }
        
        
    }
    void SetSpawnTimer()
    {
    
       spawnTimer = 5f/Mathf.Sqrt(levelManager.level);
        
    }
   void DefineSpawnCount()
    {
        if(levelManager.level>5)
        {
            spawnPointsCount=levelManager.level-4;
        }
    }
}
