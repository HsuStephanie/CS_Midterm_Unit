using UnityEngine;

namespace MidtermTuringTest
{
    public class RaycastWeaponBehavior : IWeaponBehavior
    {
        PlayerWeapon weaponScript;

        public RaycastWeaponBehavior(PlayerWeapon _weaponScript)
        {
            weaponScript = _weaponScript;
            weaponScript.weaponReference.GetComponent<MeshRenderer>().material.color = Color.green;
        }
       
        public void FireWeapon(Transform _inTransform)
        {
            Debug.Log("Firing projectible");
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

