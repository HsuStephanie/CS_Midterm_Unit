using UnityEngine;

namespace MidtermTuringTest
{
    public abstract class Interactor : MonoBehaviour
    {
        [SerializeField] protected PlayerInput _input;
        // Update is called once per frame
        void Update()
        {
            Interact();
        }

        public abstract void Interact();
        
    }
}
