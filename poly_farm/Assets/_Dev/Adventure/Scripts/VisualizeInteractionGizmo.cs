using UnityEngine;

namespace PerryPixelAdventure {
    public class VisualizeInteractionGizmo : MonoBehaviour {
        [SerializeField] PlayerInteraction playerInteraction;

        void OnDrawGizmos() {
            if (playerInteraction != null && playerInteraction.FocusedInteractable != null) {
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(transform.position, playerInteraction.FocusedInteractable.Transform.position);
            }
        }
    }
}
