using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CodeDemo
{
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] Button startGameButton;
        [SerializeField] Button switchGameStateButton;

        private void Awake()
        {
            startGameButton.onClick.AddListener(() => { GameManager.Instance.StartGame();});
            switchGameStateButton.onClick.AddListener(SwitchGameStateButton_OnClick);
        }

        void SwitchGameStateButton_OnClick()
        {
            var currentGMState = GameManager.Instance.CurrentGameState;

            if (currentGMState == GameManager.GameState.Ingame)
            {
                GameManager.Instance.SwitchState(GameManager.GameState.MainMenu);
            }
            else if (currentGMState == GameManager.GameState.MainMenu)
            {
                GameManager.Instance.SwitchState(GameManager.GameState.Ingame);
            }
        }
    }
}
