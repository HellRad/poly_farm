using UnityEngine;

namespace PerryPixelAdventure {
    public class PlayerInput : MonoBehaviour {
        public bool InputEnabled { get => inputEnabled; set => inputEnabled = value; }
        public Vector2 InputDirection => inputDirection;
        public Vector2 LastDistinctInputDirection => lastDistinctInputDirection;

        [SerializeField] PlayerInteraction playerInteraction;
        [SerializeField] KeyCode interactKey = KeyCode.E;
        [SerializeField] string horizontalInputAxisName = "Horizontal";
        [SerializeField] string verticalInputAxisName = "Vertical";
        Vector2 inputDirection;
        Vector2 lastDistinctInputDirection;
        bool inputEnabled = true;

        void Update() {
            if (inputEnabled) {
                TryInteract();
            }
        }

        void TryInteract() {
            if (Input.GetKeyDown(interactKey)) {
                playerInteraction.InteractWithFocusedInteractable();
            }
        }

        public Vector2 SetGetCurrentInputDirection() {
            if (!inputEnabled) {
                inputDirection = Vector2.zero;
                return inputDirection;
            }

            float horizontalInput = Input.GetAxisRaw(horizontalInputAxisName); // gets the horizontal input axis value (between -1 and 1)
            float verticalInput = Input.GetAxisRaw(verticalInputAxisName); //gets the vertical input axis value (between -1 and 1)
            inputDirection = new Vector2(horizontalInput, verticalInput); // creates a new vector2 with the horizontal and vertical input values. But beware, if moving diagonally, the magnitude of this vector will be greater than 1, which can lead to faster movement.
            if (inputDirection != Vector2.zero && lastDistinctInputDirection != inputDirection) {
                lastDistinctInputDirection = inputDirection; // if the input direction is not zero and is different from the last distinct input direction, update the last distinct input direction. This is useful for keeping track of the last direction the player moved in, which can be used for animations or other logic.
            }
            return inputDirection;
        }
    }
}
