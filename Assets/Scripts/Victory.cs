using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Victory : MonoBehaviour
{
  [SerializeField]
  public GameObject VictoryScreen;

  [SerializeField]
  public Button NewGame;

  void Awake()
  {
    GameManager.OnGameStatesChanged += VictoryManagerOnGameStateChanged;
  }

  void Start()
  {
    VictoryScreen.gameObject.SetActive(false);
  }

  void OnDestroy()
  {
    GameManager.OnGameStatesChanged -= VictoryManagerOnGameStateChanged;
  }

  private void VictoryManagerOnGameStateChanged(GameState state)
  {
    VictoryScreen.gameObject.SetActive(state == GameState.Victory);
  }

  void Update()
  {
    // if (Input.GetKeyDown(KeyCode.G))
    // {
    //   Debug.Log("gee");
    //   GameManager.instance.UpdateGameState(GameState.Victory);
    // }
  }

  public void BackToMainMenu()
  {
    SceneManager.LoadScene(0);
    GameManager.instance.changeNewgameMusic();
  }
}