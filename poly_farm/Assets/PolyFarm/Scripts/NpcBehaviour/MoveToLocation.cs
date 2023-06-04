using UnityEngine;

namespace CodeDemo
{
    public class MoveToLocation : NpcBehaviour
    {
        public override BehaviourState currentBehavourState { get; set; } = BehaviourState.Began;

        [SerializeField] private Transform location;
        [SerializeField] private NpcBehaviour whenLocationReachedBehaviour;
        [SerializeField] private float minDistanceToTrigger = 1;
        NpcBehaviourExecuter npcBehaviourExecuter;

        public override void Begin(NpcBehaviourExecuter executer)
        {
            npcBehaviourExecuter = executer;

            if (!location)
            {
                currentBehavourState = BehaviourState.Stopped;
                return;
            }

            var agent = npcBehaviourExecuter.navMeshAgent;
            agent.destination = location.position;
            agent.isStopped = false;

            Debug.Log($"Behaviour -MoveToLocation- started");
            currentBehavourState = BehaviourState.Executing;
        }

        public override void Execute()
        {
            if (currentBehavourState != BehaviourState.Executing)
            {
                return;
            }

            var agent = npcBehaviourExecuter.navMeshAgent;

            agent.destination = location.position;

            if (agent.remainingDistance < minDistanceToTrigger)
            {
                Stop();
                npcBehaviourExecuter.SwitchBehaviour(whenLocationReachedBehaviour);
            }
        }

        public override void Stop()
        {
            npcBehaviourExecuter.navMeshAgent.isStopped = true;
            currentBehavourState = BehaviourState.Stopped;
            Debug.Log($"Behaviour -MoveToLocation- stopped");
        }
    }
}
