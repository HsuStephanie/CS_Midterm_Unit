using UnityEngine;
using UnityEngine.AI;


namespace MidtermTuringTest
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] Transform _targetPosition;
        NavMeshAgent _agent;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _targetPosition = GameObject.FindGameObjectWithTag("Player").transform;


        }

        // Update is called once per frame
        void Update()
        {
            _agent.destination = _targetPosition.position;
        }
    }
}
