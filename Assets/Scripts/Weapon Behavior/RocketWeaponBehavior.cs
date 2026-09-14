using UnityEngine;

namespace MidtermTuringTest
{
    public class RocketWeaponBehavior : IShootStrategy
    {
        ShootInteractor shootInteractor;
        Transform shootPoint;

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
            if (pooledRocket != null)
            {
                pooledRocket.gameObject.SetActive(true);

                //Get rigidbody and set position of the rocket
                Rigidbody rocket = pooledRocket.GetComponent<Rigidbody>();
                rocket.transform.position = shootPoint.transform.position;
                rocket.transform.rotation = shootPoint.transform.rotation;

                //Apply force to bullet
                rocket.linearVelocity = shootPoint.forward * shootInteractor.GetShootVelocity();

                //Recycle bullet into pool
                pooledRocket.DestroyWithTime(2f);



                Debug.Log("Firing Rocket");
            }

        }


    }
}
