using UnityEngine;

namespace MidtermTuringTest
{
    public class PlayerCollisionBehavior : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {
            
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("LevelTrigger"))
            {
                GameManager.instance.ChangeGameState(GameManager.GameState.LevelStart);
            }
        }
    }
}
