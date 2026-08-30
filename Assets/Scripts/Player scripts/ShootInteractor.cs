using UnityEngine;

namespace MidtermTuringTest
{
    
    
    public class ShootInteractor : Interactor
    {
        [SerializeField] Input _inputType; //the enum from below

        [Header("Shoot")]
        [SerializeField] Rigidbody _bulletPrefab;
        [SerializeField] float _shootVelocity;
        [SerializeField] Transform _shootPoint;
        [SerializeField] PlayerMovementBehavior _playerMovementBehavior;
        
        //private variable
        float _finalShootVelocity;
        
        public override void Interact()
        {
           if (_inputType == Input.Primary && _input.primaryShootPressed || _inputType == Input.Secondary && _input.secondaryShootPressed)
            {
                Shoot();
            }
        }
        private void Shoot()
        {
            _finalShootVelocity = _playerMovementBehavior.GetForwardSpeed() + _shootVelocity; //adds velocity of the player
            Rigidbody bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            bullet.linearVelocity = _shootPoint.forward * _finalShootVelocity;
            Destroy(bullet.gameObject, 7f); //will change this to Object Pooling!
        }
       
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
