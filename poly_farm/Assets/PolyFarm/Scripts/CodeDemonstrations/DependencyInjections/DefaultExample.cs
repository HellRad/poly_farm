using System.Net.NetworkInformation;
using UnityEngine;

namespace CodeDemonstrations.DependencyInjections
{
    public class MonoMommy : MonoBehaviour
    {
        [SerializeField] MonoChick monoChickPrefab;

        void SpawnChick()
        {
            var chick = Instantiate(monoChickPrefab);
            chick.Init(this);
        }
    }

    public class MonoChick : MonoBehaviour
    {
        MonoMommy mommy;

        public void Init(MonoMommy mom)
        {
            mommy = mom;
        }
    }
}
