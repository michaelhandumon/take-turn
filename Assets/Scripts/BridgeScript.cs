using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript : MonoBehaviour
{
    Vector3 currentPosition;

    void Start() {
        transform.position +=
            transform.forward * Time.deltaTime;
    }
    void Update()
    {
        
        if (transform.position.z >= 6f) {
            transform.position +=
            transform.forward * -(Time.deltaTime);
        }
    }
}
