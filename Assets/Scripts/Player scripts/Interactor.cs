using UnityEngine;

namespace MidtermTuringTest
{
    public abstract class Interactor : MonoBehaviour
    {
       
        // Update is called once per frame
        void Update()
        {
            Interact();
        }

        public abstract void Interact();
        
    }
}
