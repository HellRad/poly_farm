using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolyFarm
{
    [CreateAssetMenu(fileName = "Plant", menuName = "ScriptableObject/Plant")]
    public class PlantSO : ScriptableObject
    {
        [field: SerializeField] public float StartingSize { get; private set; } = 0.1f;
        [field: SerializeField] public float FinalSize { get; private set; } = 1f;
        [field: SerializeField] public float GrowthSpeedPercentPerSeconds { get; private set; } = 0.01f;
    }
}
