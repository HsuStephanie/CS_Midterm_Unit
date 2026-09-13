using UnityEngine;
using UnityEngine.InputSystem;

namespace MidtermTuringTest
{
    public class PlayerWeapon : MonoBehaviour
    {
        IWeaponBehavior currentWeapon;
        public GameObject shotPoint;

        public GameObject weaponReference;

        [SerializeField] private InputActionReference switchProjectileWeapon;
        [SerializeField] private InputActionReference switchRayCastWeapon;

        public GameObject bulletProjectile;
        public GameObject rocketProjectile;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            SwitchWeapon(new ProjectileWeaponBehavior(this));
        }

        // Update is called once per frame
        void Update()
        {   
            //if input key down
            currentWeapon.FireWeapon(shotPoint.transform);
            
            
            //if input keydown
            if (switchProjectileWeapon.action.triggered)
            {
                Debug.Log("Switch to projectile weapon");
                   SwitchWeapon (new ProjectileWeaponBehavior(this));
            }
         

            // if input key down new key
            if (switchRayCastWeapon.action.triggered)
            {
                  Debug.Log("Switch to raycast weapon");
                  SwitchWeapon(new RaycastWeaponBehavior(this));
            }
          
        }


        public void SwitchWeapon(IWeaponBehavior newWeapon)
        {
            //responsible for determining which weapon used.

            currentWeapon = newWeapon;
            Debug.Log("Switched weapon behavior to: " + newWeapon.GetType().Name);
        }
    }
}
