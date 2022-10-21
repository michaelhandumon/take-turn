using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    [SerializeField]
    public TMP_Text playerName;

    public string forName;

    void Start()
    {
        if (forName == "Watergirl")
        {
            playerName.text = GameManager.instance.watergirlName;
        }

        if (forName == "Fireboy")
        {
            playerName.text = GameManager.instance.fireboyName;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
