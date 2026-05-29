using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    [SerializeField] GameObject menu;
    [SerializeField] KeyCode menuKey = KeyCode.M;
    [SerializeField] Button startGame;
    [SerializeField] Button endGame;
    bool menuOpen;

    void Awake() {
        menu.SetActive(false);
        startGame.onClick.AddListener(StartGameButton_OnClick);
        endGame.onClick.AddListener(EndGameButton_OnClick);
    }

    void OnDestroy() {
        startGame.onClick.RemoveListener(StartGameButton_OnClick);
        endGame.onClick.RemoveListener(EndGameButton_OnClick);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(menuKey)) {
            if (menuOpen) {
                menuOpen = false;
                Cursor.lockState = CursorLockMode.Locked;
                menu.SetActive(false);
            }
            else {
                menuOpen = true;
                Cursor.lockState = CursorLockMode.Confined;
                menu.SetActive(true);
            }
        }
    }

    void StartGameButton_OnClick() {
        Debug.Log("Starting game, do start logic here");
    }

    void EndGameButton_OnClick() {
# if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
