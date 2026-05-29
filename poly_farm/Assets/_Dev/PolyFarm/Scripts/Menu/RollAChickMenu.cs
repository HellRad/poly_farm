using UnityEngine;
using UnityEngine.UI;

namespace PolyFarm {
    public class RollAChickMenu : MonoBehaviour {
        [SerializeField] Button quitGame;

        void Awake() {
            quitGame.onClick.AddListener(QuitGame);
        }

        public void QuitGame() {
            Debug.Log("Quitting game, do quit logic here");
            DoQuitGame();
            int number = 1;
            int newNumber = AddNumbers(number, 2);
        }

        int AddNumbers(int a, int b) {
            int addedNumbers = a + b;
            return addedNumbers;
        }

        void DoQuitGame() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}
