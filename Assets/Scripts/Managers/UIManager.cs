using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace MidtermTuringTest
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI healthDisplay;
        [SerializeField] GameObject gameOverPanel;

        [SerializeField] GameObject gameEndScreen;
         [SerializeField] GameObject pausePanel;

        [SerializeField] Image playerPointer;

        [SerializeField] HealthScript healthScript;

        void Awake()
        {
            //subscribed to health scripts events
            healthScript.OnHealthChanged += UpdateHealthDisplay;
            healthScript.OnDeath += ShowGameOver;
        }


        public void UpdateHealthDisplay(float currentHealth)
        {
            currentHealth = healthScript.currentHealth;
            healthDisplay.text = "Health: " + currentHealth.ToString("F0");

        }

        public void ShowGameOver()
        {
            gameOverPanel.SetActive(true);
            playerPointer.gameObject.SetActive(false);

        }
        public void ShowGameComplete()
        {
            gameEndScreen.SetActive(true);
            playerPointer.gameObject.SetActive(false);
        }
        public void ShowGamePause()
        {
            
            if (pausePanel.activeInHierarchy == true)
            {
                pausePanel.SetActive(false);
            }
            else pausePanel.SetActive(true);
            


        }
    }
}
