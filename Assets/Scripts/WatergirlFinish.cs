using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatergirlFinish : MonoBehaviour
{
    void OnTriggerEnter(Collider trig)
    {
        Debug.Log(trig.gameObject.name);

        if (trig.gameObject.name == "PlayerOne")
        {
            if (GameManager.instance.fireboyFinished)
            {
                GameManager.instance.UpdateGameState(GameState.Victory);
            }
            else
            {
                Debug.Log("finished ka na");
                GameManager.instance.watergirlFinished = true;
            }
        }
    }

    void OnTriggerExit(Collider trig)
    {
        if (trig.gameObject.name == "PlayerOne" && GameManager.instance.watergirlFinished)
        {
            GameManager.instance.watergirlFinished = false;
        }
    }
}
