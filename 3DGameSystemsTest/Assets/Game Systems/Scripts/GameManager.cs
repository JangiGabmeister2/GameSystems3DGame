using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameStates gameState;
    private static GameManager _gameManager;
    public static GameManager GameManagerInstance
    {
        get => _gameManager;
        private set
        {
            if (_gameManager == null)
            {
                _gameManager = value;
            }
            else if (_gameManager != value)
            {
                Debug.Log($"{nameof(GameManager)} instance already exists. Destroy duplicate. [insert Highlander quote]");
                Destroy(value);
            }
        }
    }

    private void Awake()
    {
        GameManagerInstance = this;
    }

    private void Start()
    {
        gameState = GameStates.GameState;
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameStates.MenuState:
                if (Cursor.visible == false)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
            case GameStates.GameState:
                if (Cursor.visible == true)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
            case GameStates.DeathState:
                if (Cursor.visible == true)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
            default:
                if (Cursor.visible == true)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
        }
    }
}

public enum GameStates
{
    MenuState,
    GameState,
    DeathState
}