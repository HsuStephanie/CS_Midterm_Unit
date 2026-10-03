using System.Collections;
using UnityEngine;

namespace MidtermTuringTest
{

    public class PlayerSpecificDoorOpen : MonoBehaviour
    {
        
        static readonly int openCloseHash = Animator.StringToHash("OpenClose");
        [SerializeField] Animator _animator;
        bool _doorOpen;


        void Awake()
        {            
            _animator.Play(openCloseHash, 0, 0f);
            _animator.SetFloat("Speed", 0f);

        }
        void OnTriggerEnter(Collider other)
        {
            if (_doorOpen || !other.CompareTag("Player")) return;

            _doorOpen = true;
            _animator.SetBool("TriggerPressed", true);
            _animator.SetFloat("Speed", 1f);
            _animator.Play(openCloseHash, 0, 0f);
        }

        
    }
}
