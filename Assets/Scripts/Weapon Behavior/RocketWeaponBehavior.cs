using UnityEngine;

namespace MidtermTuringTest
{
    public class RocketWeaponBehavior : IShootStrategy
    {
        ShootInteractor shootInteractor;
        Transform shootPoint;

        int audioClipIndex = 4;
        [Header("Object pool reference")]
        [SerializeField] ObjectPool objectPool;

        public RocketWeaponBehavior(ShootInteractor _shootInteractor)
        {
            shootInteractor = _shootInteractor;
            shootPoint = _shootInteractor.GetShootPoint();

            shootInteractor.GetGunRenderer().material.color = Color.purple;
        }

        public void FireWeapon()
        {

            //Get a rocket from the pool
            PooledObject pooledRocket = ObjectPool.instance.GetPooledObject();
            AudioManager.instance.PlaySFX(audioClipIndex);
            if (pooledRocket != null)
            {
                //Activate pooled rocket
                pooledRocket.gameObject.SetActive(true);
                
                 //get pooled object projectile script and initialize
                ProjectileScript projectileScript = pooledRocket.GetComponent<ProjectileScript>();
                projectileScript.Initialize(shootInteractor.gameObject.tag);
             
                //Get rigidbody and set position of the rocket
                Rigidbody rocket = pooledRocket.GetComponent<Rigidbody>();
                rocket.transform.position = shootPoint.transform.position;
                rocket.transform.rotation = shootPoint.transform.rotation;

                //Apply force to bullet
                rocket.linearVelocity = shootPoint.forward * shootInteractor.GetShootVelocity();

                //Recycle bullet into pool
                ObjectPool.instance.DestroyPooledObject(pooledRocket, 4f);

                Debug.Log("Firing Rocket");
            }

        }


    }
}
