using UnityEngine;
using UnityEngine.AI;

namespace MidtermTuringTest
{
    public class EnemyController : MonoBehaviour
    {
         private EnemyState _currentState = null;
         [SerializeField] HealthScript healthScript = null;
        NavMeshAgent agent;
        public Transform target {get; private set;}
       public  float attackRange {get; private set;}
        public bool canAttack {get; private set;}
        public Transform projectileSpawnReference;

        void Awake()
        {
            
            healthScript.OnDeath += OnDeathResponse;
            attackRange = 10f;
            target = GameObject.FindGameObjectWithTag("Player").transform;
            canAttack = false;
          
        }

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

        public void OnDeathResponse()
        {
            Destroy(gameObject);
        }

    }
}
