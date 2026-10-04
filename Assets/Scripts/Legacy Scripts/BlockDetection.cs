using UnityEngine;
using System.Collections.Generic;
using System;

namespace MidtermTuringTest
{
    public class BlockDetection : MonoBehaviour
    {
        public DoorOpenClose door; //Door will assign block detectors to itself

        List<Collider> blocks = new List<Collider>(); //containing blocks that we detect

        public event Action<BlockDetection> Placed;
        public event Action <BlockDetection> Removed;


        void OnTriggerEnter(Collider other)
        {
               blocks.Add(other); //adding new blocks to the list
               Placed?.Invoke(this);
            if (!door)
            {
                Debug.LogWarning(transform.parent.name + "does not have a door!");
                return;
            }
         
            door.UnlockDoor(this);
        }

        void OnTriggerExit(Collider other)
        {
            blocks.Remove(other); //remove it when the block leaves
            Removed?.Invoke(this);
            if (blocks.Count == 0)
            {
                door.LockDoor(this);
            }
        }
    }
}
