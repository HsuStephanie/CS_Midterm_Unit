using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

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
        [SerializeField] Camera cinematicCamera = null;

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
                }

                else if (currentGameState == GameState.GamePlaying)
                {
                    ChangeGameState(GameState.GamePaused);
                }
            }


        }

        //change between game states

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
        }
        void OnGameEnd()
        {
            Debug.Log("Game End State");
            //calculating final scores
            //determing if player won, lost 
            //figuring out what scene to go to next

        }
        void OnGameOver()
        {
            Debug.Log("GameOVer State");
            //handles logic when player dies

        }

        void OnLevelStart()
        {
            Debug.Log("Level start State");
            //could handles start cinematics. tutorials, instructions
            //starting cut scenes
            playerCamera.enabled = false;
            cinematicCamera.enabled = true;

            StartCoroutine(ChangeStateDelay(GameState.GamePlaying, 2f));

        }
        void OnLevelEnd()
        {
            Debug.Log("Level end State");
            //when the player finishes a level

        }


        void OnGamePaused()

        {
            Debug.Log("Game paused State");
            // Time.timeScale = 0f;

        }
        void OnGamePlaying()
        {
            Debug.Log("Game playing");
            Time.timeScale = 1f;
            playerCamera.enabled = true;
            cinematicCamera.enabled = false;
        }


        //this is a placeholder
        private IEnumerator ChangeStateDelay(GameState newState, float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            ChangeGameState(newState);

        }

    }

}
