using UnityEngine;

namespace PerryPixelAdventure {

    public class PlayerMovement : MonoBehaviour {
        public Vector2 CurrentMovementVector => currentMovementVector;

        [SerializeField] PlayerInput playerInput;
        [SerializeField] Rigidbody2D rb;
        [SerializeField] float movementSpeed = 7f;
        Vector2 currentMovementVector;

        void Update() {
            TrySetCurrentMovementVector();
        }

        void FixedUpdate() {
            Move();
        }

        void TrySetCurrentMovementVector() {
            SetCurrentMovementVector(playerInput.SetGetCurrentInputDirection());
        }

        void SetCurrentMovementVector(Vector2 inputDirection) {
            currentMovementVector = (inputDirection).normalized; // normalizes the input direction vector, which means it will have a magnitude of 1, regardless of the original magnitude. This ensures that diagonal movement is not faster than horizontal or vertical movement.
        }

        void Move() {
            rb.linearVelocity = currentMovementVector * movementSpeed;
        }
    }
}
