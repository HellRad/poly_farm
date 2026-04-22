using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace PolyFarm.RollAChicken {
    public class GameManager : MonoBehaviour {
        public static GameManager Instance { get; private set; }

        [SerializeField] TMP_Text scoreText;
        [SerializeField] RectTransform gameOverPanel;
        [SerializeField] int scoreToWin = 8;
        int score;

        void Awake() {
            AssignSingletonReference();
            if(gameOverPanel) gameOverPanel.gameObject.SetActive(false);
        }

        void AssignSingletonReference() {
            if (Instance != null && Instance != this) {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        public void CollectCollectible() {
            score++;
            
            if (scoreText) scoreText.text = "Score: " + score;
            
            if (score >= scoreToWin) {
                if (gameOverPanel) {
                    gameOverPanel.gameObject.SetActive(true);
                }
            }
        }

        public void RestartGame() {
            // Reload the current scene to reset the game state
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
