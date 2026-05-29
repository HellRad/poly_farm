using UnityEngine;

namespace PennyPixelEndless {
    public class Barrier : MonoBehaviour {
        [SerializeField] GameManager gameManager;
        [SerializeField] string obstacleTag = "Obstacle";

        void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag(obstacleTag)) {
                gameManager.AddPoint();
            }
        }
    }
}
