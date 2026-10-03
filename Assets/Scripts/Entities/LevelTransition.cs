using UnityEngine;
using UnityEngine.Playables;



namespace MidtermTuringTest
{
    public class LevelTransition : MonoBehaviour
    {
        [SerializeField] string currentLevelName;

        public PlayableDirector director;
        public LevelManager manager;

        void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.CompareTag("Player"))
            {
                //Assign currentLevel in GameManager to the LevelManager attached to the level
                GameManager.instance.currentLevel = manager;

                //play level cinematic. handles changing game state
                director.Play();

                Debug.Log("Loading Level: " + currentLevelName);
                gameObject.SetActive(false);


            }
        }
    }
}
