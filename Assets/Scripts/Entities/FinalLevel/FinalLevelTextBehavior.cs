using TMPro;
using UnityEngine;

namespace MidtermTuringTest
{
    public class FinalLevelTextBehavior : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI finalLevelText;

        void OnTriggerEnter(Collider other)
        {
            finalLevelText.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
