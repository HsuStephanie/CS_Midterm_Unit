using UnityEngine;

namespace MidtermTuringTest
{
    public class ButtonInteractor : MonoBehaviour, ISelectable
    {
        public void OnSelect()
        {
          Debug.Log("Button selected");   
        }
        public void OnHoverEnter()
        {
            Debug.Log("Button!");
        }
        public void OnHoverExit()
        {
            Debug.Log("No button!");
            {
                
            }
        }
    }
}
