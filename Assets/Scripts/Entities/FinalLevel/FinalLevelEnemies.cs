using System.Collections.Generic;
using UnityEngine;

namespace MidtermTuringTest
{
    public class FinalLevelEnemies : MonoBehaviour
    {
        [SerializeField] EnemySpawnManager enemySpawnManager;
        [SerializeField] LevelManager levelManager;
        [SerializeField] List<GameObject> enemies = new List<GameObject>();
        [SerializeField] bool hasSpawned;
        [SerializeField] bool bossTriggered;
        void OnEnable()
        {
            enemySpawnManager.EnemySpawned += HandleEnemySpawned;

            foreach(GameObject enemy in enemySpawnManager.SpawnedEnemies)
            {
                if (!enemies.Contains(enemy))
                enemies.Add(enemy);
            }
        }
        void OnDisable()
        {
            if (enemySpawnManager != null)
            {
                enemySpawnManager.EnemySpawned -= HandleEnemySpawned;
            }
        }

        void HandleEnemySpawned(GameObject enemy)
        {
            enemies.Add(enemy);
            hasSpawned = true;
        }

        void Update()
        {
            if (!hasSpawned || bossTriggered) return;
            enemies.RemoveAll(e => e == null);
            {
                if (enemies.Count == 0)
                {
                    bossTriggered = true;
                    levelManager.LoadFinalBoss();
                }
            }
        }
    }
}
