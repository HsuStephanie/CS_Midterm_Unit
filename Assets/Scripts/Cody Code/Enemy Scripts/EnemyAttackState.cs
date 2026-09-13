using UnityEngine;

namespace MidtermTuringTest
{
    public class EnemyAttackState : EnemyState
    {
         public EnemyAttackState(EnemyController enemyController) : base(enemyController)
        {
            _controller = enemyController;
        }

        public override void OnStateEntered()
        {
             Debug .Log("Enemy has entered Attack State");
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
