using UnityEngine;

namespace MidtermTuringTest
{
    
    
    public class ShootInteractor : Interactor
    {
        [SerializeField] Input _inputType; //the enum from below

        [Header("Shoot")]
        // [SerializeField] Rigidbody _bulletPrefab;
        [SerializeField] float _shootVelocity;
        [SerializeField] Transform _shootPoint;
        [SerializeField] PlayerMovementBehavior _playerMovementBehavior;
        
    //    [SerializeField] MeshRenderer gunRenderer;
        //private variable
        float _finalShootVelocity;

        public override void Interact()
        {
           if (_inputType == Input.Primary && PlayerInput.instance.primaryShootPressed ||
           _inputType == Input.Secondary && PlayerInput.instance.secondaryShootPressed)
            {
                Shoot();
            } 
        }
        private void Shoot()
        {
            _finalShootVelocity = _playerMovementBehavior.GetForwardSpeed() + _shootVelocity; //adds velocity of the player
            //Object pooling
            //grabs first available bullet from unused objects list
            PooledObject pooledBullet = ObjectPool.instance.GetPooledObject();
            if (pooledBullet != null)
            {
                //get bullet from the pool
                pooledBullet.gameObject.SetActive(true);

                //get rigidbody, set position, and set rotation
                Rigidbody bullet = pooledBullet.GetComponent<Rigidbody>();
                bullet.transform.position = _shootPoint.position;
                bullet.transform.rotation = _shootPoint.rotation;

                //apply linear force to bullet
                bullet.linearVelocity = _shootPoint.forward * _shootVelocity;
                //recycle bullet and put back into unused object pool
                pooledBullet.DestroyWithTime(3f);
            }
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
