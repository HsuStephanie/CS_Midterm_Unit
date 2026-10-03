using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MidtermTuringTest
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI healthDisplay;
        [SerializeField] GameObject gameOverPanel;
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
    }
}
