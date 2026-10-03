using UnityEngine;

namespace MidtermTuringTest
{
    public class LevelActivator : MonoBehaviour
    {
       [SerializeField] GameObject levelToActivate;


        void OnTriggerEnter(Collider other)
        {
              if (other.gameObject.CompareTag("Player"))
            {
                levelToActivate.SetActive(true);
                gameObject.SetActive(false);


            }
        }
    }
}
