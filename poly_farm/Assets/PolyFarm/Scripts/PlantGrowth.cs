using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;

namespace PolyFarm
{
    [RequireComponent(typeof(Plant))]
    public class PlantGrowth : MonoBehaviour
    {
        public bool GrownUp { get; private set; }

        [SerializeField] PlantSO _settings;
        //[SerializeField] float _startingSize = 0.1f;
        //[SerializeField] float _finalSize = 1f;
        //[SerializeField] float _growthSpeedInPercentPerSeconds = 0.1f;

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
            var size = _settings.StartingSize;

            if (GrownUp) { size = _settings.FinalSize;}

            gameObject.transform.localScale = new Vector3(size, size, size);
        }

        void Grow()
        {
            var currentScale = gameObject.transform.localScale;
            var finalSize = _settings.FinalSize;

            if (currentScale.x >= finalSize)
            {
                GrownUp= true;
                gameObject.transform.localScale = new Vector3(finalSize, finalSize, finalSize);
                this.enabled = false;
                return;
            }

            var growthMultiplicator = (1 + _settings.GrowthSpeedPercentPerSeconds)  * Time.deltaTime;
            var newScale = currentScale + currentScale * growthMultiplicator;
            gameObject.transform.localScale = newScale;
        }
    }
}
