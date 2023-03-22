using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

namespace PolyFarm
{
    public class PlantGrowingProcess : MonoBehaviour
    {
        [SerializeField] private Plant[] _plants;

        private void Awake()
        {
            _plants =  Object.FindObjectsByType<Plant>(FindObjectsSortMode.InstanceID);
        }

        [ContextMenu("CheckHowManyPlantsAreRdy")]
        public int CheckHowManyCabbagesAreRdy()
        {
            int numberOfGrownCabbages = 0;

            foreach (var plant in _plants)
            {
                if (plant.PlantGrowth.GrownUp) //add "&& plant.name.Contains("Cabbage")" to scan only for cabbages 
                { 
                    numberOfGrownCabbages++; 
                }
            }

            Debug.Log("Number of grown cabbages: " + numberOfGrownCabbages);
            return numberOfGrownCabbages;
        }

        [ContextMenu("MakePlantIll")]
        public void MakePlantIll()
        {
            //TODO: add random number

            for (int i = 0; i < _plants.Length; i++)
            {
                if (i == 5)
                {
                    _plants[i].MakeIll();
                }
            }
        }

        [ContextMenu("GetAllCabbagaesThatAreGrownUp")]
        public void GetAllCabbagaesThatAreGrownUp()
        {
            var cabbages = new List<Plant>();

            foreach (var plant in _plants)
            {
                if (plant.name.Contains("Cabbage") && plant.PlantGrowth.GrownUp)
                {
                    cabbages.Add(plant);
                }
            }

            Debug.Log("Number of grown cabbages: " + cabbages.Count());
        }

        [ContextMenu("LinqGetAllCabbagaesThatAreGrownUp")]
        public void LinqGetAllCabbagaesThatAreGrownUp()
        {
            var grownCabbages = from p in _plants
                                where p.PlantGrowth.GrownUp && p.name.Contains("Cabbage")
                                select p;

            Debug.Log("Number of grown cabbages: " + grownCabbages.Count());
        }
    }
}