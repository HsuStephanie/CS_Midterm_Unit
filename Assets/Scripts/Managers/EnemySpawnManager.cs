using System;
using UnityEngine;
using System.Collections.Generic;


namespace MidtermTuringTest
{
    public class EnemySpawnManager : MonoBehaviour
    {
        [SerializeField] Transform[] spawnPoints;
        [SerializeField] GameObject enemyPrefab;

        public event Action<GameObject> EnemySpawned;
         readonly List<GameObject> spawnedEnemies = new List<GameObject>();
        public IReadOnlyList<GameObject> SpawnedEnemies => spawnedEnemies;

        public void SpawnEnemies()
        {
           
            foreach (Transform spawnPoint in spawnPoints)
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation, transform);
                spawnedEnemies.Add(enemy);
                EnemySpawned?.Invoke(enemy);
            }
         
        }
       

    }
}
