using UnityEngine;

namespace MidtermTuringTest
{
    public class EnemySpawnManager : MonoBehaviour
    {
        [SerializeField] Transform[] spawnPoints;
        [SerializeField] GameObject enemyPrefab;
        
       public void SpawnEnemies()
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                Instantiate(enemyPrefab, spawnPoint.transform);
            }
        }
       

    }
}
