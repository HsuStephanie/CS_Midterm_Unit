using UnityEngine;

namespace MidtermTuringTest
{


    public class ShootInteractor : Interactor
    {
        [SerializeField] Input _inputType; //the enum from below

        IShootStrategy _currentShootStrategy;

        [Header("Shoot")]
        // [SerializeField] Rigidbody _bulletPrefab;
        [SerializeField] float _shootVelocity;
        [SerializeField] Transform _shootPoint;
        [SerializeField] PlayerMovementBehavior _playerMovementBehavior;
        [Header("Gun mesh renderer")]
        [SerializeField] MeshRenderer gunRenderer;
        //private variable
        float _finalShootVelocity;

        void Start()
        {
            //default weapon set to bullet
            SwitchWeapon(new BulletWeaponBehavior(this));

        }


        public override void Interact()
        {
            if (_inputType == Input.Primary && PlayerInput.instance.primaryShootPressed ||
            _inputType == Input.Secondary && PlayerInput.instance.secondaryShootPressed)
            {
                Shoot();
            }

            //Switch to bullet weapon
            if (PlayerInput.instance.alpha1Pressed)
            {
                SwitchWeapon(new BulletWeaponBehavior(this));
            }

            //Swich to rocket weapon
            if (PlayerInput.instance.alpha2Pressed)
            {
                SwitchWeapon(new RocketWeaponBehavior(this));
            }
        }
        /// <summary>
        ///FireWeapon() is a method called from the Interface IShootStrategy of Bullet or Rocket
        /// </summary>
        private void Shoot()
        {
            Debug.Log("Shooting");
            _finalShootVelocity = _playerMovementBehavior.GetForwardSpeed() + _shootVelocity; //adds velocity of the player
            _currentShootStrategy.FireWeapon();
        }


        /// <summary>
        /// Allows us to access shootpoint transform position and rotation
        /// </summary>
        /// <returns></returns>
        public Transform GetShootPoint()
        {
            return _shootPoint;
        }
        /// <summary>
        /// Allows us to access shooting velocity
        /// </summary>
        /// <returns></returns>
        public float GetShootVelocity()
        {
            return _shootVelocity;
        }
        public MeshRenderer GetGunRenderer()
        {
            return gunRenderer;
        }


        public void SwitchWeapon(IShootStrategy newWeapon)
        {
            //responsible for determining which weapon used.

            _currentShootStrategy = newWeapon;
            Debug.Log("Switched weapon behavior to: " + newWeapon.GetType().Name);
        }

        /// <summary>
        /// types of shooting that the player has. Enum will select which type of bullet
        /// </summary>
        public enum Input
        {
            Primary,
            Secondary
        }
    }
}
