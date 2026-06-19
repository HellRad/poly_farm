using UnityEngine;

namespace PennyPixelPlattformer {

    public class PlayerPlattformer : MonoBehaviour {

        [SerializeField] GameManager gameManager;
        [SerializeField] TextBubble textBubble;
        [SerializeField] Rigidbody2D rb;
        [SerializeField] Animator animator;
        [SerializeField] LayerMask groundCheckMask;
        [SerializeField] KeyCode jumpKey = KeyCode.Space;
        [SerializeField] ForceMode2D jumpForceMode = ForceMode2D.Impulse;
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] GameObject gravestonePrefab;
        [SerializeField] float maxMovementSpeed = 6f;
        [SerializeField] float jumpForce = 15f;
        [SerializeField] float groundCheckLength = 0.9f;
        [SerializeField] Vector2 groundCheckRayOrigin = new(0f, 0.2f);
        [SerializeField] float gravestoneSpawnDelay = 0.5f;
        [SerializeField] float destroyDelay = 0.8f;
        [SerializeField] string animatorRunningKey = "running";
        [SerializeField] string animatorJumpingKey = "jumping";
        [SerializeField] string animatorHurtKey = "hurt";
        [SerializeField] string obstacleTag = "Obstacle";
        [SerializeField] string collectibleTag = "Collectible";
        [SerializeField] string finishTag = "Finish";
        [SerializeField] string hurtText = "Ouch!";
        [SerializeField] string collectionText = "Yummy!";
        bool inputEnabled = true;
        float horizontalInput;
        bool isJumping;
        float currentDirection;
        bool isGrounded;

        void Update() {
            GetUserInput();
            GetCharacterDirection();
            ManageGroundedState();
            SetAnimatorJumpingVariable();
            ManageSpriteRendererDirection();
            SetAnimatorMovementVariables();
        }

        /// <summary>
        /// Catch the Horizontal Input Axis and save the result in a variable
        /// </summary>
        void GetUserInput() {
            GetHorizontalUserInput();
            GetVerticalUserInput();
        }

        void GetHorizontalUserInput() {
            horizontalInput = 0;
            if (!inputEnabled) { return; }
            horizontalInput = Input.GetAxis("Horizontal");
        }

        void GetVerticalUserInput() {
            if (!inputEnabled) { return; }
            if (isGrounded && !isJumping && Input.GetKeyDown(jumpKey)) {
                isJumping = true;
            }
        }

        /// <summary>
        /// Monitor the current direction of the player and save the result to a currentDirection variable
        /// </summary>
        void GetCharacterDirection() {
            if (horizontalInput != 0 && horizontalInput != currentDirection) {
                currentDirection = horizontalInput;
            }
        }

        /// <summary>
        /// Make a Ground Check and set the grounded variable according to the check
        /// </summary>
        void ManageGroundedState() {
            isGrounded = false;

            RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + groundCheckRayOrigin, Vector2.down, groundCheckLength, groundCheckMask);

            if (hit.collider != null) {
                isGrounded = true;
                return;
            }
        }

        /// <summary>
        /// Always set animator variable JUMPING to FALSE when GROUNDED = TRUE
        /// </summary>
        void SetAnimatorJumpingVariable() {
            animator.SetBool(animatorJumpingKey, !isGrounded);
        }

        /// <summary>
        /// Flip the sprite renderer according to the direction the character is facing
        /// </summary>
        void ManageSpriteRendererDirection() {
            if (currentDirection > 0 && spriteRenderer.flipX) {
                spriteRenderer.flipX = false;
                return;
            }

            if (currentDirection < 0 && !spriteRenderer.flipX) {
                spriteRenderer.flipX = true;
            }
        }

        /// <summary>
        /// Check the this game object is moving and change animation accordingly
        /// </summary>
        void SetAnimatorMovementVariables() {
            if (horizontalInput != 0f) {
                animator.SetBool(animatorRunningKey, true);
                return;
            }
            animator.SetBool(animatorRunningKey, false);
        }

        void FixedUpdate() {
            ApplyHorizontalMovement();
            ApplyVerticalMovement();
        }

        void ApplyHorizontalMovement() {
            Vector2 movementVector = new(horizontalInput * maxMovementSpeed, rb.linearVelocityY);
            rb.linearVelocity = movementVector;
        }

        void ApplyVerticalMovement() {
            if (isJumping) {
                isJumping = false;
                Vector2 direction = new(rb.linearVelocityX, jumpForce);
                rb.AddForce(direction, jumpForceMode);
            }
        }

        void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.CompareTag(collectibleTag)) {
                CollectCollectible(collision.gameObject);
            }

            if (collision.gameObject.CompareTag(obstacleTag)) {
                HurtPlayer();
            }

            if (collision.gameObject.CompareTag(finishTag)) {
                WinGame();
            }
        }

        void CollectCollectible(GameObject collectible) {
            gameManager.AddPoint();
            textBubble.DisplayText(collectionText);
            Destroy(collectible);
        }

        void HurtPlayer() {
            inputEnabled = false;
            animator.SetTrigger(animatorHurtKey);
            textBubble.DisplayText(hurtText);
            gameManager.EnterGameOverState();
            Invoke(nameof(SpawnGravestone), gravestoneSpawnDelay);
            Destroy(this.gameObject, destroyDelay);
        }

        void SpawnGravestone() {
            Instantiate(gravestonePrefab, this.transform.position, Quaternion.identity);
        }

        void WinGame() {
            inputEnabled = false;
            gameManager.EnterGameWinState();
        }

        /// <summary>
        /// Draw Ground Cast Ray to better understand what the ground cast is doing
        /// </summary>
        void OnDrawGizmos() {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine((Vector2)transform.position + groundCheckRayOrigin, (Vector2)transform.position + groundCheckRayOrigin + Vector2.down * groundCheckLength);
        }
    }
}
