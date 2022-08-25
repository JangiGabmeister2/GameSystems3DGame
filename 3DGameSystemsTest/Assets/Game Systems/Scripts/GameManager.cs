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
}

public enum GameStates
{
    MenuState,
    GameState,
    DeathState
}