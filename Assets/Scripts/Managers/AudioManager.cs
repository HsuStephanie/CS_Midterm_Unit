
using System;
using UnityEngine;
using UnityEngine.Audio;

namespace MidtermTuringTest
{
    public class AudioManager : MonoBehaviour
    {
       [SerializeField] AudioClip introClip;
       [SerializeField] AudioSource audioSource;
      
        public static AudioManager instance;

        [SerializeField] AudioClip[] audioClips;


        void Awake()
        {
            if (instance !=null)
            {
                Destroy(gameObject);
            }
            else 
            instance = this;

            
        }

        public void PlayClip()
        {
           audioSource.PlayOneShot(introClip);
        }

        public void PlaySFX(int index)
        {
            audioSource.PlayOneShot(audioClips[index]);
        }

        public void PlayerChangeHealth()
        {
            PlaySFX(2);
        }
    }
}
