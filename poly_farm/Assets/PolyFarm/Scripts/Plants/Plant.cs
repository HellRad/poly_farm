using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolyFarm
{
    public class Plant : MonoBehaviour, IFarmItem
    {
        public string GetName => _plant.name;
        [field: SerializeField] public bool IsHealthy { get; private set; } = true;
        public PlantGrowth PlantGrowth { get; private set; }

        [SerializeField] private Material _plantIllMaterial;
        private Material _defaultMaterial;
        [SerializeField] private PlantSO _plant;

        private void Awake()
        {
            PlantGrowth = GetComponent<PlantGrowth>();
        }

        public void MakeIll()
        {
            var renderers = GetComponentsInChildren<MeshRenderer>();

            if (renderers.Length > 0)
            {
                foreach (var renderer in renderers)
                {
                    _defaultMaterial = renderer.material;
                    renderer.material = _plantIllMaterial;
                    IsHealthy = false;
                }
            }
        }
    }
}
