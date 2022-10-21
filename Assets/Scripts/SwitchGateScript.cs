using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGateScript : MonoBehaviour
{
    Vector3 position = new Vector3();

    [SerializeField]
    public GameObject gate;

    public Animator gateAnim;

    void Awake()
    {
        gateAnim = gate.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FireElement>() != null || other.GetComponent<WaterElement>() != null)
        {   
            GetComponent<MeshRenderer>().material.color = Color.green;
            position =
                new Vector3(transform.position.x, 13f, transform.position.z);
            transform.position = position;

            gateAnim.ResetTrigger("close");
            gateAnim.SetTrigger("open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FireElement>() != null || other.GetComponent<WaterElement>() != null)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            position =
                new Vector3(transform.position.x, 13.2f, transform.position.z);
            transform.position = position;

            gateAnim.ResetTrigger("open");
            gateAnim.SetTrigger("close");
        }
    }
}
