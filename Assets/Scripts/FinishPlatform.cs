using UnityEngine;
using System.Collections;

public class FinishPlatform : MonoBehaviour
{
  public string playerName;

  void Update()
  {
    // if (inside)
    // {
    //   if (!arrived && teleportPadOn)
    //     Teleport();
    // }
  }

  void OnTriggerEnter(Collider trig)
  {
    Debug.Log("player name: " + trig.gameObject.name);
    Debug.Log(trig.gameObject.name);

    if (trig.gameObject.name == playerName)
    {
      if (playerName == "PlayerOne")
      {
        if (GameManager.instance.fireboyFinished)
        {
          GameManager.instance.UpdateGameState(GameState.Victory);
        }
        else
        {
          Debug.Log("finished ka na imo ya");
          GameManager.instance.watergirlFinished = true;

        }
      }

      if (playerName == "PlayerTwo")
      {
        if (GameManager.instance.watergirlFinished)
        {
          GameManager.instance.UpdateGameState(GameState.Victory);
        }
        else
        {
          Debug.Log("finished ka na");
          GameManager.instance.fireboyFinished = true;

        }
      }
    }
  }

  void OnTriggerExit(Collider trig)
  {
    if (playerName == "PlayerOne")
    {
      GameManager.instance.watergirlFinished = false;
    }


    if (playerName == "PlayerTwo" && GameManager.instance.watergirlFinished)
    {
      GameManager.instance.fireboyFinished = false;
    }
  }
}
