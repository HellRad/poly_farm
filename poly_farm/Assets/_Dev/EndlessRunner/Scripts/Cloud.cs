using UnityEngine;

namespace PennyPixelEndless {
    public class Cloud : MonoBehaviour {
        [SerializeField] float speed = 2f;
        [SerializeField] float minHeight = 1f;
        [SerializeField] float maxHeight = 4f;
        [SerializeField] Rigidbody2D rb;
        [SerializeField] string leftBarrierTag = "BarrierL";
        [SerializeField] float resetPositionX = 15f;

        void FixedUpdate() {
            rb.linearVelocityX = -speed;
        }

        void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag(leftBarrierTag)) {
                transform.position = ResetPosAndGetRandomHeight();
            }
        }

        Vector2 ResetPosAndGetRandomHeight() {
            float randomY = Random.Range(minHeight, maxHeight);
            return new Vector2(resetPositionX, randomY);
        }
    }
}
