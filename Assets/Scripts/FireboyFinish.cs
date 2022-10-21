using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireboyFinish : MonoBehaviour
{
    void OnTriggerEnter(Collider trig)
    {
        Debug.Log(trig.gameObject.name);

        if (trig.gameObject.name == "PlayerTwo")
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

    void OnTriggerExit(Collider trig)
    {
        if (trig.gameObject.name == "PlayerTwo" && GameManager.instance.fireboyFinished)
        {
            GameManager.instance.fireboyFinished = false;
        }
    }
}
