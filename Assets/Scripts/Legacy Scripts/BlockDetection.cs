using UnityEngine;
using System.Collections.Generic;

namespace MidtermTuringTest
{
    public class BlockDetection : MonoBehaviour
    {
        public DoorOpenClose door; //Door will assign block detectors to itself

        List<Collider> blocks = new List<Collider>(); //containing blocks that we detect


        void OnTriggerEnter(Collider other)
        {
            if (!door)
            {
                Debug.LogWarning(transform.parent.name + "does not have a door!");
                return;
            }
            blocks.Add(other); //adding new blocks to the list
            door.UnlockDoor(this);
        }

        void OnTriggerExit(Collider other)
        {
            blocks.Remove(other); //remove it when the block leaves
            if (blocks.Count == 0)
            {
                door.LockDoor(this);
            }
        }
    }
}
