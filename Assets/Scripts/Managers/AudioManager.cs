
using UnityEngine;

namespace MidtermTuringTest
{
    public class AudioManager : MonoBehaviour
    {
       [SerializeField] AudioClip introClip;
       [SerializeField] AudioSource audioSource;

        public static AudioManager instance;



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
    }
}
