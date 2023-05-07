using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolyFarm
{
    [CreateAssetMenu(fileName = "InteractionSettings", menuName = "ScriptableObject/InteractionSettings")]
    public class InteractionSettingsSO : ScriptableObject
    {
        [field: SerializeField] public string InteractionText { get; private set; } = "Interact";
    }
}