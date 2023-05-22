using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeDemo
{
    public class GameManager : MonoBehaviour
    {
        public enum GameState
        {
            NONE,
            MainMenu,
            Ingame
        }

        public GameState StartingState;
        public GameState CurrentGameState { get; private set; }
        public GameData GameData = new GameData();

        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            if (Instance)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            Debug.Log("Game Started");
            SetDefaultState();
        }

        public void SetDefaultState()
        {
            CurrentGameState = GameState.MainMenu;
        }

        public void SwitchState(GameState newState)
        {
            if (newState == CurrentGameState)
            {
                Debug.LogWarning($"Can't change game state, allready in state: {CurrentGameState.ToString()}");
                return;
            }

            CurrentGameState = newState;

            switch (newState)
            {
                case GameState.MainMenu:
                    Debug.Log("You are in the main menu");
                    break;
                case GameState.Ingame:
                    Debug.Log("You are in game");
                    break;
                default:
                    break;
            }
        }
    }
}
