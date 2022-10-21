using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
     Vector3 _elevatorFirstPosition = new Vector3(3f, 27f, -49f);
    public void OnTriggerStay(Collider other)
    {   
            transform.position +=
                transform.up * Time.deltaTime;

            if (transform.position.y > _elevatorFirstPosition.y)
            {
                transform.position = _elevatorFirstPosition;
            }
            
    }
}
