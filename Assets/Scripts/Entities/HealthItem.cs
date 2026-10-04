using UnityEngine;

namespace MidtermTuringTest
{
    public class HealthItem : MonoBehaviour
    {
        [SerializeField] float health = 20f;
        HealthScript playerHealth;

        void Start()
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthScript>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (playerHealth == null) return;
            playerHealth.Heal(health);
            gameObject.SetActive(false);
        }
    }
}
