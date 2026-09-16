using UnityEditor;
using UnityEngine;

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
            Paused,
            GamePlaying
        }
        
        public GameState currentGameState = GameState.GameIntro;
        
        
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
                ChangeGameState(GameState.Paused);
            }
            if (currentGameState == GameState.Paused && PlayerInput.instance.pausePressed)
            {
                ChangeGameState(GameState.GamePlaying);
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
                case GameState.Paused:
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

           ChangeGameState(GameState.GamePlaying);

        }
        void OnLevelEnd()
        {
            Debug.Log("Level end State");
            //when the player finishes a level

        }


        void OnGamePaused()

        {
            Debug.Log("Game paused State");
            Time.timeScale = 0f;
            
        }
        void OnGamePlaying()
        {
            Debug.Log("Game playing");
            Time.timeScale = 1f;
        }

    }

}
