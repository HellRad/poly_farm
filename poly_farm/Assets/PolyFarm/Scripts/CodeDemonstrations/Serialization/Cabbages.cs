using System.Collections.Generic;
using UnityEngine;

namespace CodeDemo.Serialization
{
    public class CabbagesSaveData
    {
        public CabbageSaveData[] cabbages;
    }

    public class Cabbages: MonoBehaviour
    {
        public List<Cabbage> cabbages { get; private set; } = new List<Cabbage>();
        public static Cabbages Instance { get; private set; }
        const string cabbagesSaveKey = "Cabbages";

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void SubscribeCabbage(Cabbage cabbage)
        {
            cabbages.Add(cabbage);
        }

        public void DesubscribeCabbage(Cabbage cabbage)
        {
            cabbages.Remove(cabbage);
        }

        public void SaveAllCabbages()
        {
            var cabbageSaves = new List<CabbageSaveData>();
           
            //pack all the cabbages into a data object
            foreach (var cabbage in cabbages)
            {
                cabbageSaves.Add(cabbage.GetData());
            }

            var cabbagesSaveData = new CabbagesSaveData() { cabbages = cabbageSaves.ToArray() };

            CabbageSaveSystem.SaveAsJSONPlayerPrefs(this, cabbagesSaveData, cabbagesSaveKey);
        }

        public void LoadAllCabbages()
        {
            CabbageSaveSystem.LoadFromJSONPlayerPrefs(this, cabbagesSaveKey, OnAllCabbagesLoadEnded);
        }

        void OnAllCabbagesLoadEnded(CabbagesSaveData cabbagesSaveData)
        {
            var notloadedCabbages = cabbages;
           
            foreach (var cabbage in notloadedCabbages)
            {
                foreach (var cabbageSave in cabbagesSaveData.cabbages)
                {
                    if (cabbage.id == cabbageSave.id)
                    {
                        cabbage.ApplyData(cabbageSave);
                        notloadedCabbages.Remove(cabbage);
                    }
                }
            }

            foreach (var cabbage in notloadedCabbages)
            {
                Destroy(cabbage);
            }
        }
    }
}
