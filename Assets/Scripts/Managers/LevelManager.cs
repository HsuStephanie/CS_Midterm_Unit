using UnityEngine;


namespace MidtermTuringTest
{
    public class LevelManager : MonoBehaviour
    {
        
        public GameObject[] levels;
        [SerializeField] GameObject currentLevel;

        public static LevelManager instance = null;

        void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            instance = this;
        }

        public void LoadLevel(int levelIndex)
        {
            //When entering level collider, set gameobject active at index chosen
            levels[levelIndex].SetActive(true);
       }

        public void UnloadLevel(int levelIndex)
        {
            //When entering next level collider, set previous gameobjects as inactive
            levels[levelIndex].SetActive(false);
        }

    }
}
