using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PolyFarm
{
    public class RayInteraction : MonoBehaviour
    {
        [field: SerializeField] public InteractionSettingsSO interactionSettings = null;
        [SerializeField] private UnityEvent onInteract;

        public void InteractWith()
        {
            onInteract?.Invoke();
        }
    }
}
