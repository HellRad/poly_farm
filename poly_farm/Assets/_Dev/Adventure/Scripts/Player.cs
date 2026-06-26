using UnityEngine;

namespace PerryPixelAdventure {
    public class Player : MonoBehaviour {
        public string Designation => designation;
        [SerializeField] string designation;

        void Awake() {
            GameManager.Instance.RegisterPlayer(this);
        }
    }
}
