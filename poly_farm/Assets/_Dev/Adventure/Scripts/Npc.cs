using UnityEngine;

namespace PerryPixelAdventure {
    public class Npc : MonoBehaviour {
        public string Designation => designation;
        [SerializeField] string designation;
    }
}
