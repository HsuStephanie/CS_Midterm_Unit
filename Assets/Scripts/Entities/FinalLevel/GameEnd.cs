using UnityEngine;

namespace MidtermTuringTest
{
    public class GameEnd : MonoBehaviour
    {
        
        [SerializeField] GameObject gameEndScreen;

        void OnTriggerEnter(Collider other)
        {
            gameEndScreen.SetActive(true);
        }
    }
}
