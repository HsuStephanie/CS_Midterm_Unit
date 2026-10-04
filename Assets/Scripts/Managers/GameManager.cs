using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace MidtermTuringTest
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Scenes/Levels
        ///     Title Screen
        ///     Level 1
        ///     Level 2
        /// 
        /// Game States
        ///     Pause
        ///     Game Over
        ///     etc.
        /// </summary>
        public enum GameState
        {
            GameIntro,
            GameStart,
            GameOver,
            GameEnd,
            LevelStart,
            LevelEnd,
            GamePaused,
            GamePlaying
        }

        public GameState currentGameState = GameState.GameIntro;

        [Header("Cameras")]
        [SerializeField] Camera playerCamera = null;
        // [SerializeField] PlayableDirector level1Director;

        [Header("UI Panels")]
        [SerializeField] UIManager uIManager;
       

        [Header("Level Managers")]
        public List<LevelManager>levels = new List<LevelManager>();
        public LevelManager currentLevel;


        //singleton pattern
        public static GameManager instance = null;

        void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
                instance = this;

        }
        private void Start()
        {
            Debug.Log("Gamemanager started");
            ChangeGameState(GameState.GameStart);
        }


        void Update()
        {

            if (PlayerInput.instance.pausePressed)
            {
                if (currentGameState == GameState.GamePaused)
                {
                    ChangeGameState(GameState.GamePlaying);
                    uIManager.ShowGamePause();

                }

                else if (currentGameState == GameState.GamePlaying)
                {
                    ChangeGameState(GameState.GamePaused);
                    
                }
            }


        }

        //Change between game states
        public void ChangeGameState(GameState newState)
        {
            currentGameState = newState;

            switch (newState)
            {
                case GameState.GameIntro:
                    OnGameIntro();
                    break;
                case GameState.GameStart:
                    OnGameStart();
                    break;
                case GameState.GameOver:
                    OnGameOver();
                    break;
                case GameState.GameEnd:
                    OnGameEnd();
                    break;
                case GameState.LevelStart:
                    OnLevelStart();
                    break;
                case GameState.LevelEnd:
                    OnLevelEnd();
                    break;
                case GameState.GamePaused:
                    OnGamePaused();
                    break;
                case GameState.GamePlaying:
                    OnGamePlaying();
                    break;
                
            }
        }

        //Signals for cinematic start/End. These are like events
        public void CinematicStart()
        {
            Debug.Log("Cinematic started");
            // level1Director.Play();
            ChangeGameState(GameState.LevelStart);

        }
        public void CinematicEnd()
        {

            Debug.Log("Cinematic ended");
            playerCamera.transform.localPosition = Vector3.zero;
            ChangeGameState(GameState.GamePlaying);


        }

        void OnGameIntro()
        {
            Debug.Log("Game Intro State");
            StartCoroutine(ChangeStateDelay(GameState.GameStart, 2f));

        }

        void OnGameStart()
        {
            //Do whatever we need to do when the game starts
            Debug.Log("Game Start State");
            ChangeGameState(GameState.GamePlaying);

            //loading screens
            //load the object poolers for this level
            AudioManager.instance.PlayClip();
        }
        void OnGameEnd()
        {
            Debug.Log("Game End State");
            uIManager.ShowGameComplete();
            Time.timeScale = 0f;
            //calculating final scores
            //determing if player won, lost 
            //figuring out what scene to go to next

        }
        void OnGameOver()
        {
            Debug.Log("GameOver State");
            uIManager.ShowGameOver();
            Time.timeScale = 0f;
            //handles logic when player dies

        }

        void OnLevelStart()
        {
            Debug.Log("Level start State");
            //could handles start cinematics. tutorials, instructions
            currentLevel.LevelStart();
            //starting cut scene


        }
        void OnLevelEnd()
        {
            Debug.Log("Level end State");
            // currentLevel.LevelEnd();
            //when the player finishes a level
            ChangeStateDelay(GameState.GamePlaying, 0.5f);

        }


        void OnGamePaused()

        {
            Debug.Log("Game paused State");
            uIManager.ShowGamePause();
            Time.timeScale = 0f;


        }
        void OnGamePlaying()
        {
            Debug.Log("Game playing");
            Time.timeScale = 1f;
            playerCamera.enabled = true;
        }


        //this is a placeholder
        private IEnumerator ChangeStateDelay(GameState newState, float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            ChangeGameState(newState);

        }

    }

}
