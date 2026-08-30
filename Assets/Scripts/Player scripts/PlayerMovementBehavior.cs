using UnityEngine;


namespace MidtermTuringTest
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementBehavior : MonoBehaviour
    {
        [SerializeField] PlayerInput _playerInput;

        [Header("PlayerMovement")]
        [SerializeField] float _moveSpeed = 5f;
        [SerializeField] float _gravity = -9.8f;
        [SerializeField] float _sprintMultiplier = 1.5f;
        [SerializeField] float _moveMultipler = 1f;

        [Header("Ground Check")]
        [SerializeField] Transform _groundCheck;
        [SerializeField] LayerMask _groundMask;
        [SerializeField] float _groundCheckDistance = 0.2f;

        CharacterController _characterController;
        Vector3 _playerVelocity;

        public bool isGrounded {get; private set;}

        

        void Start()
        {
            _characterController= GetComponent<CharacterController>();

        }


        void Update()
        {
  
            GroundCheck();
            MovePlayer();
        }

        private void GroundCheck()
        {
            isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckDistance); //creates a sphere to check for the ground
        }
        private void MovePlayer()
        {
             //Make player sprint
            _moveMultipler = _playerInput.sprintHeld? _sprintMultiplier : 1f;
            //movement
            Vector3 move = transform.forward * _playerInput.verticalInput + transform.right * _playerInput.horizontalInput;

            _characterController.Move(move * _moveSpeed * _moveMultipler * Time.deltaTime);

            //Keep player grounded
            if (isGrounded && _playerVelocity.y <0)
            {
                _playerVelocity.y = -2f;
            }
            //Gravity
            _playerVelocity.y += _gravity * Time.deltaTime;

            //Vertical movement (telling controller it can move with player's velocity)
            _characterController.Move(_playerVelocity * Time.deltaTime);            
        }
        public void SetYVelocity(float Value)
        {
            _playerVelocity.y = Value;
        }
        public float GetForwardSpeed()
        {
            return _playerInput.verticalInput* _moveSpeed * _moveMultipler;
        }
    }
}
