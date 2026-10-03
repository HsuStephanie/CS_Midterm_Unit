using UnityEngine;

namespace MidtermTuringTest
{
    public class BulletWeaponBehavior : IShootStrategy
    {
        ShootInteractor shootInteractor;
        Transform shootPoint;

        public BulletWeaponBehavior(ShootInteractor _shootInteractor)
        {
            shootInteractor = _shootInteractor;
            shootPoint = _shootInteractor.GetShootPoint();

            shootInteractor.GetGunRenderer().material.color = Color.green;
        }

        public void FireWeapon()
        {
            //Get a bullet from the pool
            PooledObject pooledBullet = ObjectPool.instance.GetPooledObject();
            
            if (pooledBullet != null)
            {
                
                //get pooled object projectile script and initialize
                ProjectileScript projectileScript = pooledBullet.GetComponent<ProjectileScript>();
                projectileScript.Initialize(shootInteractor.gameObject.tag);
                
                //Get rigidbody and set position of the bullet
                Rigidbody bullet = pooledBullet.GetComponent<Rigidbody>();
                bullet.transform.position = shootPoint.transform.position;
                bullet.transform.rotation = shootPoint.transform.rotation;

                //Apply force to bullet
                bullet.linearVelocity = shootPoint.forward * shootInteractor.GetShootVelocity();

                //Recycle bullet into pool
                ObjectPool.instance.DestroyPooledObject(pooledBullet, 4f);

            }


        }





    }
}

