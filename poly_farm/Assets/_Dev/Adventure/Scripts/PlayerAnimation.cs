using UnityEngine;

namespace PerryPixelAdventure {
    public class PlayerAnimation : MonoBehaviour {
        [SerializeField] Animator animator;
        [SerializeField] PlayerInput playerInput;
        [SerializeField] PlayerMovement playerMovement;
        [SerializeField] string xInputKey = "xInput";
        [SerializeField] string yInputKey = "yInput";
        [SerializeField] string lastXDirectionKey = "lastXDirection";
        [SerializeField] string lastYDirectionKey = "lastYDirection";
        [SerializeField] string movementMagnitudeKey = "movementMagnitude";

        void Update() {
            SetAnimatorKeys();
        }

        void SetAnimatorKeys() {
            animator.SetFloat(xInputKey, playerInput.InputDirection.x);
            animator.SetFloat(yInputKey, playerInput.InputDirection.y);
            animator.SetFloat(lastXDirectionKey, playerInput.LastDistinctInputDirection.x);
            animator.SetFloat(lastYDirectionKey, playerInput.LastDistinctInputDirection.y);
            animator.SetFloat(movementMagnitudeKey, playerMovement.CurrentMovementVector.magnitude);
        }
    }
}
