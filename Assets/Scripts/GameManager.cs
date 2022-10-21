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

    public bool watergirlFinished = false;

    public bool fireboyFinished = false;

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
        Debug.Log (newState);
        state = newState;
        switch (state)
        {
            case GameState.GameOver:
                handleGameOver();
                break;
            case GameState.Victory:
                handleVictory();
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

    void handleGameOver()
    {
        Debug.Log("Game Over");
    }

    void handleVictory()
    {
        Debug.Log("Victory");
    }

    void handleContinue()
    {
        Debug.Log("Continue");
    }

    void handleNone()
    {
        Debug.Log("None State");
    }
}
