using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameOver : MonoBehaviour
{
    [SerializeField]
    public GameObject GameOverScreen;

    [SerializeField]
    public GameObject AdPanel;

    [SerializeField]
    public Button ContinueButton;

    public float skipAdTime = 10f;

    float currentTime;

    [SerializeField]
    public TMP_Text countdownText;

    bool startAdTimer = false;

    void Awake()
    {
        GameManager.OnGameStatesChanged += GameOverManagerOnGameStateChanged;
    }

    void Start()
    {
        GameOverScreen.gameObject.SetActive(false);
        AdPanel.gameObject.SetActive(false);
        ContinueButton.gameObject.SetActive(false);
        currentTime = skipAdTime;
    }

    void OnDestroy()
    {
        GameManager.OnGameStatesChanged -= GameOverManagerOnGameStateChanged;
    }

    private void GameOverManagerOnGameStateChanged(GameState state)
    {
        GameOverScreen.gameObject.SetActive(state == GameState.GameOver);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameManager.instance.UpdateGameState(GameState.GameOver);
        }

        if (startAdTimer)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                countdownText.gameObject.SetActive(false);
                ContinueButton.gameObject.SetActive(true);
                currentTime = 0;
            }
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void WatchAd()
    {
        GameOverScreen.gameObject.SetActive(false);
        AdPanel.gameObject.SetActive(true);
        startAdTimer = true;
    }

    public void ContinueGame()
    {
        startAdTimer = false;
        AdPanel.gameObject.SetActive(false);
        GameManager.instance.UpdateGameState(GameState.Continue);
    }
}
