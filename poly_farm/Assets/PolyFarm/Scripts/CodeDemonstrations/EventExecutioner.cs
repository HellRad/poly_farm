using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeDemo
{
    public class EventExecutioner : MonoBehaviour
    {
        [SerializeField] private EventHolder eventHolder;

        private void Start()
        {
            eventHolder.AnAction?.Invoke();     
        }
    }
}