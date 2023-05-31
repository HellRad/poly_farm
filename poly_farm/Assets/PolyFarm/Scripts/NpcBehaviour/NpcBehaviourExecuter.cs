using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace CodeDemo
{
    public class NpcBehaviourExecuter : MonoBehaviour
    {
        public NavMeshAgent navMeshAgent;
        [SerializeField] private NpcBehaviour startingBehaviour;
        private NpcBehaviour currentBehaviour;

        void Start()
        {
            if (!currentBehaviour && startingBehaviour) 
            { 
                currentBehaviour = startingBehaviour; 
            }

            if (currentBehaviour)
            {
                currentBehaviour.Begin(this);
            }
        }

        void Update()
        {
            if (!currentBehaviour){return;}
            currentBehaviour.Execute();
        }

        public void SwitchBehaviour(NpcBehaviour newBehaviour)
        {
            currentBehaviour = newBehaviour;
            currentBehaviour.Begin(this);
        }
    }
}
