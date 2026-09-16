using System;
using UnityEngine;

namespace MidtermTuringTest
{
    public class HealthScript : MonoBehaviour
    {
        public float currentHealth = 100f;

        public event Action<float> OnHealthChanged;
        public event Action OnDeath;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

            bool isSubscribed = OnHealthChanged != null;
            if (isSubscribed)
            {
                OnHealthChanged?.Invoke(currentHealth);

            }


        }

        public void TakeDamage(float amount)
        {
            currentHealth -= amount;
            //asking is there anything subscribed to the event OnHealthChanged. If null, will not invoke, else will invoke currentHealth
            OnHealthChanged?.Invoke(currentHealth);

            if (currentHealth <= 0f)
            {
                Die();
            }

        }

        public void Die()
        {
            OnDeath?.Invoke(); 
            Debug.Log("You ddead");
            Destroy(gameObject);
        }
    }
}
