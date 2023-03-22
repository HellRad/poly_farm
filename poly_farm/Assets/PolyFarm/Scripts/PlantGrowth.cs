using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;

namespace PolyFarm
{
    [RequireComponent(typeof(Plant))]
    public class PlantGrowth : MonoBehaviour
    {
        [field: SerializeField] public bool GrownUp { get; private set; }

        [SerializeField] float _startingSize = 0.1f;
        [SerializeField] float _finalSize = 1f;
        [SerializeField] float _growthSpeedInPercentPerSeconds = 0.1f;

        void Awake()
        {
            ScaleToStartingSize();
        }

        void Update()
        {
            if (GrownUp) { return; }
            Grow();
        }

        void ScaleToStartingSize()
        {
            var size = _startingSize;

            if (GrownUp) { size = _finalSize;}

            gameObject.transform.localScale = new Vector3(size, size, size);
        }

        void Grow()
        {
            var currentScale = gameObject.transform.localScale;

            if (currentScale.x >= _finalSize)
            {
                GrownUp= true;
                gameObject.transform.localScale = new Vector3(_finalSize, _finalSize, _finalSize);
                this.enabled = false;
                return;
            }

            var growthMultiplicator = (1 + _growthSpeedInPercentPerSeconds)  * Time.deltaTime;
            var newScale = currentScale + currentScale * growthMultiplicator;
            gameObject.transform.localScale = newScale;
        }
    }
}
