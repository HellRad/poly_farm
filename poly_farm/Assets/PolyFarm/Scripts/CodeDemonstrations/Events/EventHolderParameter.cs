using System;
using UnityEngine;

namespace CodeDemo.Events
{
    public class EventHolderParameter : MonoBehaviour
    {
        public Action<string> AnAction { get; set; }
       
        [SerializeField] string playerName = "Bob";

        //This is how you trigger a delegate with parameter
        void Start()
        {
            AnAction?.Invoke(playerName);
        }
    }
}
