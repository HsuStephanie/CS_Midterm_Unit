using UnityEngine;
using UnityEngine.Events;


namespace MidtermTuringTest
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Unity events")]
        [SerializeField] UnityEvent OnLevelStart;
        [SerializeField] UnityEvent OnLevelEnd;
        private bool isFinalLevel=false;


 
        public void LevelStart()
        {
            OnLevelStart?.Invoke();
            // GameManager.instance.ChangeGameState(GameManager.GameState.LevelStart);
        }

            public void LevelEnd()
        {
            OnLevelEnd?.Invoke();
            // if (isFinalLevel)
            // {
            //     // GameManager.instance.ChangeGameState(GameManager.GameState.GameEnd);
            // }
            // else
            // GameManager.instance.ChangeGameState(GameManager.GameState.LevelEnd);
        }

        //----------------Not working
    //     public void LoadLevel(int levelIndex)
    //     {
    //         //When entering level collider, set gameobject active at index chosen
    //         levels[levelIndex].SetActive(true);
    //    }

    //     public void UnloadLevel(int levelIndex)
    //     {
    //         //When entering next level collider, set previous gameobjects as inactive
    //         levels[levelIndex].SetActive(false);
    //     }

        //----------------- 

    }
}
