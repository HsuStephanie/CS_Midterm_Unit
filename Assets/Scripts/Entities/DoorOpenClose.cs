using System;
using UnityEngine;
using UnityEngine.Events;

namespace MidtermTuringTest
{
    public class DoorOpenClose : MonoBehaviour
    {
        [SerializeField] BlockDetection[] blockDetectors;
        [SerializeField] Renderer[] UnlockLights;

        int audioClipIndex = 0;

        Animator _animator;
        bool[] unlocks;

        bool doorOpen = false;

        [Header("Unity Event")]
        [SerializeField] UnityEvent OnBlockPlaced;

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

            //ensures that door does not automatically play when game starts
            _animator.Play("OpenClose", 0, 0f);
            _animator.SetFloat("Speed", 0f);

        }

        void SetUnlocked(BlockDetection blockDetection, bool unlocked)
        {
            int index = Array.IndexOf(blockDetectors, blockDetection);
            if (index<0) return;
            
            bool wasUnlocked = unlocks[index];
            unlocks[index] = unlocked;
            UnlockLights[index].material.SetColor("_EmissionColor",(unlocked?Color.green : Color.red) * 20f);
           
            UpdateDoor();
            if (unlocked && !wasUnlocked)
            {
                OnBlockPlaced?.Invoke();
            }
        
        }

        public void UpdateDoor()
        {
            bool ShouldBeOpen = Array.TrueForAll(unlocks, u => u);

            if (ShouldBeOpen == doorOpen) return;
            doorOpen = ShouldBeOpen;

            AudioManager.instance.PlaySFX(0);

            float t = Mathf.Clamp01(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
            _animator.Play("OpenClose", 0, t);
            _animator.SetFloat("Speed", doorOpen?1f: -1f);
        }


        public void UnlockDoor(BlockDetection blockDetection)
        {
            SetUnlocked(blockDetection, true);
            
        }

        public void LockDoor(BlockDetection blockDetection)
        {
            SetUnlocked(blockDetection, false);
          
        }

    
    }
}
