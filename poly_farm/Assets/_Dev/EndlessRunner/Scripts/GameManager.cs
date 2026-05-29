using TMPro;
using UnityEngine;

namespace PennyPixelEndless {
    public class GameManager : MonoBehaviour {
        [SerializeField] KeyCode restartKey = KeyCode.R;
        [SerializeField] string gameSceneName = "EndlessRunner";
        [SerializeField] string leftBarrierTag = "BarrierL";
        [SerializeField] string obstacleTag = "Obstacle";
        [SerializeField] string propsTag = "Props";
        [SerializeField] TMP_Text pointsText;
        [SerializeField] Obstacle obstacle;
        [SerializeField] string gameOverText = "Game Over!";
        [SerializeField] SpriteRenderer background;
        [SerializeField] Color backgroundGameOverTint = Color.red;
        [SerializeField] GameObject restartCaption;
        int points;

        // Update is called once per frame
        void Update() {
            TryRestartGame();
        }

        public void AddPoint() {
            points++;
            pointsText.text = points.ToString();
        }

        public void EnterGameOverState() {
            Destroy(obstacle.gameObject);
            pointsText.text = gameOverText;
            background.color = backgroundGameOverTint;
            restartCaption.SetActive(true);

            var props = GameObject.FindGameObjectsWithTag(propsTag);
            foreach (var prop in props) {
                Destroy(prop);
            }
        }

        void TryRestartGame() {
            if (Input.GetKey(restartKey)) {
                UnityEngine.SceneManagement.SceneManager.LoadScene(gameSceneName);
            }
        }
    }
}
