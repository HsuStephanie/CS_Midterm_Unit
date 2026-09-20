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
            _controller.agent.isStopped = false;
        }
        

        public override void OnStateExit()
        {
            _controller.agent.isStopped = true;
        }

        public override void OnStateUpdate()
        {
            Debug.Log("Follow update...");
            //move towards player
            _controller.agent.SetDestination(_controller.target.transform.position);
            Vector3 lookAtTarget = _controller.target.transform.position;
            lookAtTarget.y = _controller.transform.position.y;
            _controller.gameObject.transform.LookAt(lookAtTarget);

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
                    _controller.ChangeState(new EnemyIdleState(_controller));
                }
            }
            //if player is in range to attack, switch to attack
            if (distance <= _controller.attackRange)
            {
                _controller.ChangeState(new EnemyAttackState (_controller));
            }
       
        }
    }
}
