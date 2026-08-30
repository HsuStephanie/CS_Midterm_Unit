using UnityEngine;

namespace MidtermTuringTest
{
    public class Simpleinteractor : Interactor
    {
        [SerializeField] Camera cam;
        [SerializeField] LayerMask interactionLayer;
        [SerializeField] float interactionDistance;


        RaycastHit _raycastHit;
        ISelectable _iSelectable;

        public override void Interact()
        {
           //cast a ray. calcualted based on screen size
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
            if (Physics.Raycast(ray, out _raycastHit, interactionDistance, interactionLayer))
            {
                _iSelectable = _raycastHit.transform.GetComponent<ISelectable>(); 

                if (_iSelectable != null)
                {
                    _iSelectable.OnHoverEnter();
                     if (_input.activatePressed)
                {
                    _iSelectable.OnSelect();
                }
                }
               
            }

            if (_raycastHit.transform == null && _iSelectable != null)
            {
                _iSelectable.OnHoverExit();
                _iSelectable = null;
            }
            //         Debug.DrawRay(_cam.transform.position, _cam.transform.forward * _interactionDistance, Color.bisque);
    
        }
    }

    
}
