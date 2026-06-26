using UnityEngine;

namespace PerryPixelAdventure {

    public class Collectable : MonoBehaviour, IInteractable, IHighlightable {
        public string Name => mainObject.name;
        public Transform Transform => transform;
        public Transform HighlightTransform => highlightTransform;

        [SerializeField] GameObject mainObject;
        [SerializeField] Transform highlightTransform;

        public void Interact() {
            throw new System.NotImplementedException();
        }
    }
}
