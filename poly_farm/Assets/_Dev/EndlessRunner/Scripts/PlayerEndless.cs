using UnityEngine;

namespace PennyPixelEndless {

    public class PlayerEndless : MonoBehaviour {
        [SerializeField] GameManager gameManager;
        [SerializeField] Rigidbody2D rb;
        [SerializeField] KeyCode jumpKey = KeyCode.Space;
        [SerializeField] float jumpForce = 8f;
        [SerializeField] ForceMode2D jumpForceMode = ForceMode2D.Impulse;
        [SerializeField] Animator animator;
        [SerializeField] string runAnimationTrigger = "running";
        [SerializeField] string jumpAnimationTrigger = "jumping";
        [SerializeField] string hurtAnimationTrigger = "hurt";
        [SerializeField] float destroyDelay = 0.8f;
        [SerializeField] string obstacleTag = "Obstacle";

        void Start() {
            animator.SetBool(runAnimationTrigger, true);
            animator.SetBool(jumpAnimationTrigger, false);
        }

        void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag(obstacleTag)) {
                animator.SetBool(hurtAnimationTrigger, true);
                gameManager.EnterGameOverState();
                Destroy(this.gameObject, destroyDelay);
            }
        }

        void Update() {
            TryJump();
            TryRun();
        }

        void TryJump() {
            if (Input.GetKeyDown(jumpKey)) {
                rb.AddForce(Vector2.up * jumpForce, jumpForceMode);
                animator.SetBool(jumpAnimationTrigger, true);
                animator.SetBool(runAnimationTrigger, false);
            }
        }

        void TryRun() {
            if (Input.GetKeyUp(jumpKey)) {
                animator.SetBool(jumpAnimationTrigger, false);
                animator.SetBool(runAnimationTrigger, true);
            }
        }
    }
}
