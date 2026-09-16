using UnityEngine;
using UnityEngine.AI;

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
            Debug.Log("Enemy has entered Attack State");
        }
        public override void OnStateUpdate()
        {
            Debug.Log("Attack update");
            //Read distance to player
            float distance = Vector3.Distance(_controller.transform.position, _controller.target.transform.position);
            Vector3 lookAtTarget = _controller.target.transform.position;
            lookAtTarget.y = _controller.transform.position.y;
            _controller.gameObject.transform.LookAt(lookAtTarget);

            //go back to follow state if player is out of attack range
            if (distance > _controller.attackRange)
            {
                _controller.ChangeState(new EnemyFollowState(_controller));
            }
            if (_controller.canAttack)
            {
                //get pooled bullet from object pool
                PooledObject pooledBullet = ObjectPool.instance.GetPooledObject();

                if (pooledBullet != null)
                {
                    //Activate the pooled bullet
                    pooledBullet.gameObject.SetActive(true);

                    //get pooled object projectile script and initialize
                    ProjectileScript projectileScript = pooledBullet.GetComponent<ProjectileScript>();
                    projectileScript.Initialize(_controller.gameObject.tag);

                    //Get rigidbody and set position of the bullet
                    Rigidbody bullet = pooledBullet.GetComponent<Rigidbody>();
                    bullet.transform.position = _controller.projectileSpawnReference.transform.position;
                    bullet.transform.rotation =  _controller.transform.rotation;

                    //Apply force to bullet
                    bullet.linearVelocity = _controller.transform.forward * 10f;

                    //Recycle bullet into pool
                    pooledBullet.DestroyWithTime(2f);

                }


            }



        }

        public override void OnStateExit()
        {
            // _controller.agent.isStopped = false;
        }
    }
}
