using System.Collections;
using UnityEngine;

namespace MidtermTuringTest
{
    public class DoorTriggerScript : MonoBehaviour
    {
        [SerializeField] string openTag = "Player";
        
        [SerializeField] Animator _animator;
        float _delayTime = 3f;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(openTag))
            {
                _animator.SetBool("TriggerPressed", true);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(openTag))
            {
                StartCoroutine(TimedDelay());
            }
        }

        IEnumerator TimedDelay()
        {
            yield return new WaitForSeconds(_delayTime);
            _animator.SetBool("TriggerPressed", false);
        }

    }
}
