using Unity.VisualScripting;
using UnityEngine;

namespace MidtermTuringTest
{
    public class ProjectileScript : MonoBehaviour
    {

        [SerializeField] float speed;
        [SerializeField] float damage;
        HealthScript _health;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //_health = other.GameObject.GetComponent<HealthScript>();
        }

        // Update is called once per frame
        void Update()
        {
                transform.position += transform.forward * speed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            HealthScript health = other.gameObject.GetComponent<HealthScript>();
            // if (health)
        }
    }
}
