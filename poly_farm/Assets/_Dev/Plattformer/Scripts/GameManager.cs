using TMPro;
using UnityEngine;

namespace PennyPixelPlattformer {
    public class GameManager : MonoBehaviour {
        [SerializeField] KeyCode restartKey = KeyCode.R;
        [SerializeField] TMP_Text pointsText;
        [SerializeField] TMP_Text feedbackText;
        [SerializeField] SpriteRenderer background;
        [SerializeField] GameObject restartCaption;
        [SerializeField] Color backgroundGameOverTint = Color.red;
        [SerializeField] string gameSceneName = "Plattformer";
        [SerializeField] string gameOverText = "Game Over!";
        [SerializeField] string gameWinText = "You Win!";
        int points;

        void Awake() {
            feedbackText.gameObject.SetActive(false);
            ResetPointsCounter();
        }

        // Update is called once per frame
        void Update() {
            TryRestartGame();
        }

        public void AddPoint() {
            points++;
            pointsText.text = points.ToString();
        }

        void ResetPointsCounter() {
            pointsText.text = "0";
        }

        void TryRestartGame() {
            if (Input.GetKey(restartKey)) {
                UnityEngine.SceneManagement.SceneManager.LoadScene(gameSceneName);
            }
        }

        public void EnterGameOverState() {
            feedbackText.gameObject.SetActive(true);
            feedbackText.text = gameOverText;
            background.color = backgroundGameOverTint;
            restartCaption.SetActive(true);
        }

        public void EnterGameWinState() {
            feedbackText.gameObject.SetActive(true);
            feedbackText.text = gameWinText;
            restartCaption.SetActive(true);
        }
    }
}
