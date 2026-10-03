using UnityEngine;
using UnityEngine.AI;

namespace MidtermTuringTest
{
    public class EnemyController : MonoBehaviour
    {
        public NavMeshAgent agent;
        public float moveSpeed = 3f;
       public float attackRange = 3f;
      public float detectionRange = 10f;
      public bool canAttack = true;

      public GameObject target = null;
        //Combat

       public GameObject projectileSpawnReference = null;

        //Enemy states
        EnemyState currentState = null;

        public HealthScript healthScript;
        void Awake()
        {
            
            healthScript.OnDeath += OnDeathResponse;
            target = GameObject.FindGameObjectWithTag("Player");
           
          
        }

        void Start()
        {
            Debug.Log("Starting enemy controller");
            ChangeState(new EnemyIdleState(this));
         
        }

        void Update()
        {
            if (currentState != null)
            {
                currentState.OnStateUpdate();
            }
        }

        public void ChangeState(EnemyState newState)
        {
            if (currentState != null)
            currentState.OnStateExit();

            currentState = newState; //set new state
            currentState.OnStateEntered(); //call the new state's OnStateEntered method
        }

        public void OnDeathResponse()
        {
            Destroy(gameObject);
        }

    }
}
