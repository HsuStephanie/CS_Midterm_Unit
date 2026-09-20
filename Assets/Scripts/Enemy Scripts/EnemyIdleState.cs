using UnityEngine;

namespace MidtermTuringTest
{
    public class EnemyIdleState : EnemyState
    {
        public EnemyIdleState(EnemyController enemyController) : base(enemyController)
        {
            _controller = enemyController;
        }

        public override void OnStateEntered()
        {
             Debug .Log("Enemy has entered Idle  State");
             _controller.agent.isStopped = true;
        }
        public override void OnStateUpdate()
        {
     
            
             //Run raycast to see if we see player
            float distance = Vector3.Distance(_controller.transform.position, _controller.target.transform.position);
            Vector3 direction = (_controller.target.transform.position - _controller.transform.position).normalized;
            RaycastHit hit;

            //ray cast for if player hides behind a wall/object
            if (Physics.Raycast(_controller.transform.position, direction, out hit, _controller.detectionRange))
            {
                //check if raycast did not hit the player directly
                if (hit.collider.gameObject != _controller.target)
                {
                    //only follow player if raycast sees player
                    _controller.ChangeState(new EnemyFollowState(_controller));
                }
            }
        }

        public override void OnStateExit()
        {
             _controller.agent.isStopped = false;
        }
    }
}
