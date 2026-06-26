using UnityEngine;

namespace PerryPixelAdventure {
    public class Talkable : MonoBehaviour, IInteractable {
        public Transform Transform => transform;
        public string Name => designation;

        [SerializeField] string designation;

        public void Interact() {
            throw new System.NotImplementedException();
        }
    }
}
