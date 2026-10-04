using UnityEngine;
using UnityEngine.Events;


namespace MidtermTuringTest
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Unity events")]
        [SerializeField] UnityEvent OnLevelStart;
        [SerializeField] UnityEvent OnLevelEnd;
        [SerializeField] UnityEvent OnFinalBoss;
       
        public void LevelStart()
        {
            OnLevelStart?.Invoke();
        }

        public void LevelEnd()
        {
            OnLevelEnd?.Invoke();

        }

        public void LoadFinalBoss()
        {
            OnFinalBoss?.Invoke();
        }

    }
}
