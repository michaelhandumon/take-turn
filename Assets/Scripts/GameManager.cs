using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    GameOver,
    Victory,
    Continue,
    None
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string fireboyName;

    public string watergirlName;

    public GameState state;

    public static event Action<GameState> OnGameStatesChanged;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        UpdateGameState(GameState.None);
    }

    void Update()
    {
    }

    public void setCharNames(string fbName, string wgName)
    {
        fireboyName = fbName;
        watergirlName = wgName;
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (state)
        {
            case GameState.GameOver:
                handleGameOver();
                break;
            case GameState.Victory:
                break;
            case GameState.None:
                break;
            case GameState.Continue:
                break;
            default:
                break;
        }
        OnGameStatesChanged?.Invoke(newState);
    }

    public void GoToCharacterSelection()
    {
        SceneManager.LoadScene(1);
    }

    void handleGameOver() {
        Debug.Log("Game Over");
    }
    void handleVictory() {
        Debug.Log("W");
    }
    void handleContinue() {
        Debug.Log("Continue");
    }

    void handleNone() {
        Debug.Log("None State");
    }
}
