using UnityEngine;

namespace MidtermTuringTest
{
    public class LevelEndBehavior : MonoBehaviour
    {
        [SerializeField] GameObject[] enemies;
        bool _levelEnded = false;
        LevelManager levelManager;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            levelManager = gameObject.GetComponent<LevelManager>();
            if (enemies.Length != 6)
                Debug.LogWarning($"LevelEnemyTracker: expected 6 enemies but {enemies.Length} are assigned.", this);

        }

        // Update is called once per frame
        void Update()
        {
            if (_levelEnded)
            {
                if (AllEnemiesDefeated())
                {
               
                }
            }
        }

        bool AllEnemiesDefeated()
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy != null)
                    return false;
            }
            return true;
        }
    }
}
