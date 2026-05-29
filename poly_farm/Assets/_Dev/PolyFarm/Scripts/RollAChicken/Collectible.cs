using UnityEngine;

namespace PolyFarm.RollAChicken {
    /// <summary>
    /// Attach to collectible objects. Make sure the collectible has a Collider set as "Is Trigger".
    /// Tag the player ball with "Player".
    /// </summary>
    public class Collectible : MonoBehaviour {
        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                GameManager.Instance.CollectCollectible();
                Destroy(gameObject);
            }
        }
    }
}
