using System;
using UnityEngine;



namespace MidtermTuringTest
{
    public class LevelTransition : MonoBehaviour
    {
        [SerializeField] int levelToLoad;
        [SerializeField] int levelToUnload;
        [SerializeField] bool isTutorial;

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {   
                Debug.Log("Player has entered level transition");
                GameManager.instance.ChangeGameState(GameManager.GameState.LevelStart);
                //do any other behavior needed for level transition
                LevelManager.instance.LoadLevel(levelToLoad);
                if (!isTutorial)
                LevelManager.instance.UnloadLevel(levelToUnload);

                Debug.Log("Loading: " + LevelManager.instance.levels[levelToLoad].name);
                
                gameObject.SetActive(false);
            }
        }
    }
}
