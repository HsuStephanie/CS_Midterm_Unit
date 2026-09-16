using UnityEngine;

namespace MidtermTuringTest
{
    public class EnemyFollowState : EnemyState
    {
        public EnemyFollowState(EnemyController enemyController) : base(enemyController)
        {
            _controller = enemyController;
        }

        public override void OnStateEntered()
        {

            Debug .Log("Enemy has entered Follow State");
        }
        public override void OnStateUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override void OnStateExit()
        {
            throw new System.NotImplementedException(); 
        }
    }
}
