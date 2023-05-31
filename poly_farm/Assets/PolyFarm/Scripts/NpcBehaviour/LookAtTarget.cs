using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.FilePathAttribute;

namespace CodeDemo
{
    public class LookAtTarget : NpcBehaviour
    {
        public override BehaviourState currentBehavourState { get; set; } = BehaviourState.Began;

        [SerializeField] private Transform target;
        [SerializeField] private NpcBehaviour whenTargetOusideRange;
        [SerializeField] private float range = 2;
        NpcBehaviourExecuter npcBehaviourExecuter;

        public override void Begin(NpcBehaviourExecuter executer)
        {
            npcBehaviourExecuter = executer;

            if (!target)
            {
                currentBehavourState = BehaviourState.Stopped;
                return;
            }

            var agent = npcBehaviourExecuter.navMeshAgent;
         
            agent.stoppingDistance = range;
            agent.isStopped = false;

            Debug.Log($"Behaviour -LookAtTarget- started");
            currentBehavourState = BehaviourState.Executing;
        }

        public override void Execute()
        {
            if (currentBehavourState != BehaviourState.Executing)
            {
                return;
            }

            var agent = npcBehaviourExecuter.navMeshAgent;

            agent.destination = target.position;
            agent.gameObject.transform.LookAt(target);

            if (agent.remainingDistance > range)
            {
                Stop();
                npcBehaviourExecuter.SwitchBehaviour(whenTargetOusideRange);
            }
        }

        public override void Stop()
        {
            npcBehaviourExecuter.navMeshAgent.isStopped = true;
            currentBehavourState = BehaviourState.Stopped;
            Debug.Log($"Behaviour -LookAtTarget- stopped");
        }
    }
}
