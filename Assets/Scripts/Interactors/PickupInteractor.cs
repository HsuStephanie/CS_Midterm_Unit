using UnityEngine;


namespace MidtermTuringTest
{
    public class PickupInteractor : Interactor
    {
        [SerializeField] Camera cam;
        [SerializeField] LayerMask pickupLayer;
        [SerializeField] float pickupDistance;
        [SerializeField] Transform attachTransform;

        //private variables
        bool _isPicked = false;
        RaycastHit _raycastHit;
        IPickAble _iPickable;
        public override void Interact()
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
            if (Physics.Raycast(ray, out _raycastHit, pickupDistance, pickupLayer))
            {
                if (PlayerInput.instance.activatePressed && !_isPicked)
                {
                    Debug.Log("Picking up object");
                    _iPickable = _raycastHit.transform.GetComponent<IPickAble>();
                    if (_iPickable == null)
                    return;

                    _iPickable.OnPicked(attachTransform);
                    _isPicked = true;
                    return;

                }

            }
            if (PlayerInput.instance.activatePressed && _isPicked && _iPickable != null)
            {
                Debug.Log("Dropping object");
                _iPickable.OnDropped();
                _isPicked = false;
            }
        }

    }
}
