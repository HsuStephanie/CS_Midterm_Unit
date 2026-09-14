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

           
            OnHealthChanged?.Invoke(currentHealth);
            

        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void TakeDamage(float amount)
        {
            currentHealth -= amount;
            OnHealthChanged?.Invoke(currentHealth);
            if (currentHealth<= 0f)
            {
                 Die();
            }
                
        }

        public void Die()
        {
           OnDeath.Invoke();
            Debug.Log("You ddead");
            Destroy(gameObject);
        }
    }
}
