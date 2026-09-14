using TMPro;
using UnityEngine;

namespace MidtermTuringTest
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI healthDisplay;
        public GameObject gameOverPanel;

        public HealthScript healthScript;

        void Awake()
        {
            healthScript.OnHealthChanged += UpdateHealthDisplay;
            healthScript.OnDeath += ShowGameOver;
        }
     

        public void UpdateHealthDisplay(float currentHealth)
        {
            healthDisplay.text = "Health: " + currentHealth.ToString("F0");

        
        }

        public void ShowGameOver()
        {
            gameOverPanel.SetActive(true);
        }
    }
}
