using UnityEditor;
using UnityEngine;

namespace CodeDemo.Serialization
{
    public class CabbageSaveData
    {
        public string id;
        public float growth;
    }

    public class Cabbage: MonoBehaviour
    {
        public string id = "someUniqueId"; //this should be a unique id!!!!
        float growth = 0.5f;

        string uniqueIdExample = GUID.Generate().ToString();

        void Awake()
        {
            Cabbages.Instance.SubscribeCabbage(this);   
        }

        void OnDestroy()
        {
            Cabbages.Instance.DesubscribeCabbage(this);
        }

        public CabbageSaveData GetData()
        {
            return new CabbageSaveData() { id = id, growth = growth };
        }

        public void ApplyData(CabbageSaveData saveData)
        {
            growth = saveData.growth;
        }
    }
}
