using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class SwitchCharacterScript : MonoBehaviour
{
    [Header("Switch Characters")]
    public GameObject[] characters;
    GameObject currentCharacter;

    [SerializeField] public GameObject followCamera;
    int characterIndex;

    void Start() {
        characterIndex = 0;
        currentCharacter = characters[0];
        Debug.Log(GameManager.instance.fireboyName);
        Debug.Log(GameManager.instance.watergirlName);
    }

    void Update () {
        if(Input.GetButtonDown("Switch")){
            // if (GameManager.instance.state == GameState.Victory) {
            //     return;
            // }

            // if (GameManager.instance.state == GameState.GameOver) {
            //     return;
            // }

            characterIndex++;
            
            if(characterIndex == characters.Length){
                characterIndex = 0;
            };

            followCamera.GetComponent<CinemachineVirtualCamera>().LookAt = characters[characterIndex].transform.GetChild(0);
            followCamera.GetComponent<CinemachineVirtualCamera>().Follow = characters[characterIndex].transform.GetChild(0);

            currentCharacter.GetComponent<CharacterController>().enabled = false;
            currentCharacter.GetComponent<PlayerInput>().enabled = false;

            characters[characterIndex].GetComponent<CharacterController>().enabled = true;
            characters[characterIndex].GetComponent<PlayerInput>().enabled = true;

            currentCharacter = characters[characterIndex];
        }
    }
}
