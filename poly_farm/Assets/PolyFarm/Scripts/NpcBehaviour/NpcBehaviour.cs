using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeDemo
{
    public abstract class NpcBehaviour : MonoBehaviour
    {
        public enum BehaviourState
        {
            NONE,
            Began,
            Executing,
            Stopped
        }

        public abstract BehaviourState currentBehavourState { get; set; }

        public abstract void Begin(NpcBehaviourExecuter executer);
        public abstract void Execute();
        public abstract void Stop();
    }
}
