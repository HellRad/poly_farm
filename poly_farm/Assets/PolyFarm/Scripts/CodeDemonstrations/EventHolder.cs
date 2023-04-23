using System;
using UnityEngine;
using UnityEngine.Events;

namespace CodeDemo
{
    public class EventHolder : MonoBehaviour
    {
        public Action AnAction;
        public UnityAction AUnityAction;
        public UnityEvent AUnityEvent;

        //This is how you trigger a delegate
        void Start()
        {
            AnAction?.Invoke();
            AUnityAction?.Invoke();
            AUnityEvent?.Invoke();
        }
    }
}
