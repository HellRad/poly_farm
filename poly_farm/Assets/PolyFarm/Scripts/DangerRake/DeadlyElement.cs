using UnityEngine;

namespace PolyFarm
{
    public class DeadlyElement : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            var interaction = other.GetComponent<PlayerInteraction>();
            if (interaction) 
            {
                interaction.GetHurt();
            }
        }
    }
}
