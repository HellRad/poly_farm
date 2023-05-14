using System.Net.NetworkInformation;
using UnityEngine;

namespace CodeDemonstrations.DependencyInjections
{
    public class Mommy
    {
        [SerializeField] Chick monoChickPrefab;

        void SpawnChick()
        {
            var chick = new Chick(this);
        }
    }

    public class Chick
    {
        Mommy mommy;

        public Chick(Mommy mom)
        {
            mommy = mom;
        }
    }
}
