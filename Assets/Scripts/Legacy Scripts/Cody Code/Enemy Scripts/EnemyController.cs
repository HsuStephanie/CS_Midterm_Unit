using UnityEngine;

namespace MidtermTuringTest
{
    public class EnemyController : MonoBehaviour
    {
         private EnemyState _currentState = null;

        void Start()
        {
            Debug.Log("Starting enemy controller");
            ChangeState(new EnemyIdleState(this));
            ChangeState(new EnemyAttackState(this));
            ChangeState(new EnemyAttackState(this));
        }


        public void ChangeState(EnemyState newState)
        {
            _currentState = newState; //set new state

            _currentState.OnStateEntered(); //call the new state's OnStateEntered method
        }

    }
}
