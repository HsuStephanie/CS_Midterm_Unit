using System;
using UnityEngine;

namespace MidtermTuringTest
{
    public class DoorOpenClose : MonoBehaviour
    {
        [SerializeField] BlockDetection[] blockDetectors;
        [SerializeField] Renderer[] UnlockLights;

        Animator _animator;
        bool[] unlocks;

        private void Awake()
        {
            _animator = GetComponent<Animator>();


            foreach (BlockDetection blockDetector in blockDetectors)
            {
                blockDetector.door = this;
            }

            foreach (Renderer light in UnlockLights)
            {
                light.material.SetColor("_EmissionColor", Color.red * 15f); //to make it glow, use emission
            }

            unlocks = new bool[blockDetectors.Length];

            if (blockDetectors.Length == 0)
            {
                Debug.LogWarning("Door has no block detectors");
            }

        }


        public void UnlockDoor(BlockDetection blockDetection)
        {
            unlocks[Array.IndexOf(blockDetectors, blockDetection)] = true;
            UnlockLights[Array.IndexOf(blockDetectors, blockDetection)].material.SetColor("_EmissionColor", Color.green * 20f);
            AnimateDoor();
        }

        public void LockDoor(BlockDetection blockDetection)
        {
            unlocks[Array.IndexOf(blockDetectors, blockDetection)] = false;
            UnlockLights[Array.IndexOf(blockDetectors, blockDetection)].material.SetColor("_EmissionColor", Color.red * 20f);
            AnimateDoor();
        }

        void AnimateDoor()
        {
            bool doorOpen = true;

            foreach (bool unlock in unlocks)
            {
                if (!unlock)
                {
                    doorOpen = false;
                }
            }

            if (doorOpen)
            {
                _animator.Play("OpenClose", 0, Mathf.Clamp(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime, 0f, 1f));
                _animator.SetFloat("Speed", 1f);
            }
            else
            {
                _animator.Play("OpenClose", 0, Mathf.Clamp(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime, 0f, 1f));
                _animator.SetFloat("Speed", -1f);
            }
        }





    }
}
