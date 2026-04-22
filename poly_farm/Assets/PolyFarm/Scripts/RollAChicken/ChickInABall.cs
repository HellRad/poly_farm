using UnityEngine;
using UnityEngine.InputSystem;

namespace PolyFarm.RollAChicken {
    /// <summary>
    /// Controls a rolling ball using the new Input System.
    /// Add this to the ball GameObject and assign a Rigidbody.
    /// </summary>
    public class ChickInABall : MonoBehaviour {
        [SerializeField] InputActionReference moveAction;
        [SerializeField] Rigidbody rb;
        [SerializeField] float speed = 5f;

        void Awake() {
            if (rb == null) rb = GetComponent<Rigidbody>();
            if (moveAction == null) {
                Debug.LogError("Move Action not assigned on " + gameObject.name);
            }
        }

        void FixedUpdate() {
            Vector2 inputDirection = moveAction.action.ReadValue<Vector2>();

            // #1 Set velocity directly for responsive control
            rb.linearVelocity = new Vector3(inputDirection.x, 0f, inputDirection.y) * speed;

            // #2 Alternatively, apply force for more physics-based movement
            //Vector3 force = new Vector3(inputDirection.x, 0f, inputDirection.y) * speed;
            //rb.AddForce(force, ForceMode.Force);
        }
    }
}
