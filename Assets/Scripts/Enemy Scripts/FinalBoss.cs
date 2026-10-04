using UnityEngine;

namespace MidtermTuringTest
{
    public class FinalBoss : MonoBehaviour
    {
        [SerializeField] GameObject playerPlate;

       
        void OnDisable()
        {
            playerPlate.SetActive(true);
        }
    }
}
