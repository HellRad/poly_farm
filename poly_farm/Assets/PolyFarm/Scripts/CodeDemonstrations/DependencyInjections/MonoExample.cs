using UnityEngine;

namespace CodeDemonstrations.DependencyInjections
{
    public class MonoMommy : MonoBehaviour
    {
        [SerializeField] GameObject monoChickPrefab;
        void SpawnChick()
        {
            var chick = Instantiate(monoChickPrefab).GetComponent<MonoChick>();
            chick.Init(this);
        }
        public void Hug() { }
    }

    public class MonoChick : MonoBehaviour
    {
        MonoMommy mommy;
        public void Init(MonoMommy mom)
        {
            mommy = mom;
        }
        void HugMom()
        {
            mommy.Hug();
        }
    }
}
