using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MidtermTuringTest
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Movement")]
        [SerializeField] float _moveSpeed = 5f; //without "private" it is just assumed that it is
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] Transform _cameraTransform;
        [SerializeField] bool _invertMouse;
        [SerializeField] float _gravity = -9.8f;
        [SerializeField] float _jumpVelocity = 5f;
        [SerializeField] float _sprintMultiplier = 2f;

        [Header("Ground Checks")]
        [SerializeField] Transform _groundCheck;
        [SerializeField] LayerMask _groundLayer;
        [SerializeField] float _groundCheckDistance;

        [Header("Shooting")]
        [SerializeField] Rigidbody _bulletPrefab;
        [SerializeField] float _shootForce;
        [SerializeField] Transform _shootPoint;

        [Header("Controller")]
        CharacterController _characterController;

        //Some private variables for holding
        Vector3 _playerVelocity;
        bool _isGrounded;
        float _moveMultiplier = 1;//different from sprint multiplier

        //inputs---------------
        Vector2 _moveInput;
        Vector2 _lookInput;
        float _cameraXRotation;
        bool _isSprinting;
        bool _jumpPressed;
        bool _shootPressed;


        #region InputCallBacks
        public void OnMove(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
        }
        public void OnLook(InputAction.CallbackContext context)
        {
            _lookInput = context.ReadValue<Vector2>();
        }
        public void OnSprint(InputAction.CallbackContext context)
        {
            //option 1 
            _isSprinting = context.ReadValueAsButton();
        }
        public void OnJump(InputAction.CallbackContext context)
        {
            //option 2
            if (context.performed)
                _jumpPressed = true;
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            if (context.performed)
                _shootPressed = true;
        }

        #endregion


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _characterController = GetComponent<CharacterController>();
            LockCursor();
        }

        // Update is called once per frame
        void Update()
        {
            #region  PlayerInputChecks
            RotatePlayer();
            GroundCheck();
            MovePlayer();
            if (_jumpPressed)
            {
                JumpCheck();
                _jumpPressed = false;
            }
            if (_shootPressed)
            {
                ShootBullet();
                _shootPressed = false;
            }
            #endregion

        }
        void LockCursor()
        {
            //lock cursor to center and turn visibility off
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        void RotatePlayer()
        {
            transform.Rotate(Vector3.up * _lookInput.x * _turnSpeed * Time.deltaTime);
            //want to clamp on the y axis and if choosing to invert mouse
            _cameraXRotation += _lookInput.y * _turnSpeed * Time.deltaTime * (_invertMouse? 1 : -1); 
            _cameraXRotation = Mathf.Clamp(_cameraXRotation, -85f, 85f);
            _cameraTransform.localRotation = Quaternion.Euler(_cameraXRotation, 0f,0f);
        }

        void MovePlayer()
        {
            //moving forwards, back, left, and right
            //if sprinting, give the playe the multiplier. if it's not it's normal speed of 1f

            float _moveMultiplier = _isSprinting ? _sprintMultiplier : 1f;
            Vector3 move = transform.forward * _moveInput.y + transform.right * _moveInput.x; //y is the forward for the mouse

            _characterController.Move(move * _moveSpeed * _moveMultiplier * Time.deltaTime); //Character controller has a built in Move()
            if (_isGrounded && _playerVelocity.y < 0)
            {
                //grounded but not moving
                _playerVelocity.y = -2f;

            }

            //game's gravity because there's no player rigid body
            _playerVelocity.y += _gravity * Time.deltaTime;
            _characterController.Move(_playerVelocity * Time.deltaTime);

        }

        void GroundCheck()
        {
            _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckDistance, _groundLayer);
        }
        void JumpCheck()
        {
            if (_isGrounded)
            {
                _playerVelocity.y = _jumpVelocity;
            }
        }
        void ShootBullet()
        {
            Rigidbody bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            bullet.AddForce(_shootPoint.forward * _shootForce, ForceMode.Impulse);
            Destroy(bullet.gameObject, 5f); //later to be removed for object pooling
            
        }



    }

}
