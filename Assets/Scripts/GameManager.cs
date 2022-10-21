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

    [SerializeField] AudioSource startMusic;

    [SerializeField] AudioSource gameMusic;

    [SerializeField] AudioSource gameOverMusic;

    [SerializeField] AudioSource adMusic;

    [SerializeField] AudioSource victoryMusic;

    public static event Action<GameState> OnGameStatesChanged;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        UpdateGameState(GameState.None);
        startMusic.Play();
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
                handleContinue();
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
        playGameoverMusic();
        Debug.Log("Game Over");
    }

    void handleVictory()
    {
        gameMusic.Stop();
        victoryMusic.Play();
        Debug.Log("Victory");
    }

    void handleContinue()
    {
        adMusic.Stop();
        gameMusic.Play();
        Debug.Log("Continue");
    }

    void handleNone()
    {
        Debug.Log("None State");
    }

    public void playGameMusic() {
        startMusic.Stop();
        gameMusic.Play();
    }

    public void playGameoverMusic() {
        gameMusic.Stop();
        gameOverMusic.Play();
    }

    public void playAdMusic() {
        gameOverMusic.Stop();
        adMusic.Play();
    }

    public void changeNewgameMusic() {
        victoryMusic.Stop();
        // startMusic.Play();
    }

    public void changeAdToNewGameMusic() {
        adMusic.Stop();
    }

    public void stopGameOverMusic() {
        gameOverMusic.Stop();
    }
}
