using UnityEngine;

namespace MidtermTuringTest
{
   [RequireComponent(typeof(PlayerMovementBehavior))]
    public class PlayerJumpBehavior : Interactor
    {
        [SerializeField] float _jumpVelocity= 10f;
        PlayerMovementBehavior _playerMovementBehavior;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
                _playerMovementBehavior = GetComponent<PlayerMovementBehavior>();
        }

       public override void Interact()
        {
            if (PlayerInput.instance.jumpPressed && _playerMovementBehavior.isGrounded)
            {
                _playerMovementBehavior.SetYVelocity(_jumpVelocity);
            }
        }
    }
}
