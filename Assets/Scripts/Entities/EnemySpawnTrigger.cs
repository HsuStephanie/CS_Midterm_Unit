using TMPro;
using UnityEngine;

namespace MidtermTuringTest
{
    public class EnemySpawnTrigger : MonoBehaviour
    {
        [SerializeField]EnemySpawnManager enemySpawnManager;
        [SerializeField] TextMeshProUGUI finalLevelText; 
       
        void OnTriggerEnter(Collider other)
        {
            enemySpawnManager.SpawnEnemies();
            finalLevelText.gameObject.SetActive(false);

            Destroy(gameObject);
        }
    }
}
