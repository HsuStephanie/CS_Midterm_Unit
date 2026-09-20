using UnityEngine;

namespace MidtermTuringTest
{
    public class ProjectileScript : MonoBehaviour
    {
        [Header ("Deal damage")]
        [SerializeField] float damageToPlayer = 5f;
        [SerializeField] float damageToEnemy = 20f;
        //Tag on current gameobject
        private string ownershipTag = "";


        public void Initialize(string _ownershipTag)
        {
            ownershipTag = _ownershipTag;
        }
        void OnCollisionEnter(Collision collision)
        {

            if (!collision.gameObject.CompareTag(ownershipTag))
            {
                HealthScript healthScript = collision.gameObject.GetComponent<HealthScript>();
                if (healthScript !=null)
                {
                    if (collision.gameObject.CompareTag("Player"))
                    {
                        healthScript.TakeDamage(damageToPlayer);
                    }
                    else
                    healthScript.TakeDamage(damageToEnemy);
                }

            }
            

           
            //Remove bullet if it damages something
            PooledObject pooledObject = GetComponent<PooledObject>();
            if (pooledObject != null)
            {
                pooledObject.ResetObject();
            }
            else
                Destroy(gameObject);
        }

    }
}
