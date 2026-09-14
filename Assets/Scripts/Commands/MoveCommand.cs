using UnityEditor.Analytics;
using UnityEngine;
using UnityEngine.AI;

namespace MidtermTuringTest
{
    public class MoveCommand : Command
    {
        private NavMeshAgent navMeshAgent;
        private Vector3 destination;

        public MoveCommand(NavMeshAgent _navMeshAgent, Vector3 _destination)
        {
            navMeshAgent = _navMeshAgent;
            destination = _destination;
        }
       
        public override void Execute()
        {
           navMeshAgent.SetDestination(destination);
        }

        //lambda expression
        public override bool isComplete => ReachedDestination();

        //check if navmeshagent has reached destination
        bool ReachedDestination()
        {
            if (navMeshAgent.remainingDistance >0.1f)
            {
                return false;
            }
            return true;
        }
    }
}
