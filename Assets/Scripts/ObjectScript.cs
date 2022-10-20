using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    void FixedUpdate() {
        //assuming XZ movement only for this.
        if (GetComponent<Rigidbody>().velocity != Vector3.zero) {
            if (GetComponent<Rigidbody>().velocity.x > GetComponent<Rigidbody>().velocity.z) 
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0f, 0f);
            else if (GetComponent<Rigidbody>().velocity.z > GetComponent<Rigidbody>().velocity.x) 
                GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, GetComponent<Rigidbody>().velocity.z);
        }
    }
}
