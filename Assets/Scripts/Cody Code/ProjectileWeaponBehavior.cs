using UnityEngine;

namespace MidtermTuringTest
{
    public class ProjectileWeaponBehavior : IWeaponBehavior
    {
          PlayerWeapon weaponScript;

        public ProjectileWeaponBehavior(PlayerWeapon _weaponScript)
        {
            weaponScript = _weaponScript;
            weaponScript.weaponReference.GetComponent<MeshRenderer>().material.color = Color.purple;
        }
        
        public void FireWeapon(Transform _inTranform)
        {
            Debug.Log("Firing projectible");
            //GameObject bullet = GameObject.Instantiate(weaponScript.bulletProjectile, _inTranform.position, _inTranform.rotation);
        }
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
