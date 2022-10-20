using UnityEngine;
using System.Collections;

public class FinishPlatform : MonoBehaviour
{

  public string playerTag;

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

    Debug.Log(trig.gameObject.tag);
    // Debug.Log(playerTag);
    if (trig.gameObject.tag == playerTag)
    {
      Debug.Log("prepare or trigger win");
    }

  }

  void OnTriggerExit(Collider trig)
  {
    Debug.Log("Exited");
  }
}
