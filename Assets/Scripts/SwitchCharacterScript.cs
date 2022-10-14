using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class SwitchCharacterScript : MonoBehaviour
{
    public GameObject[] characters;
    GameObject currentCharacter;

    [SerializeField] public GameObject followCamera; 
    // private ThirdPersonController thirdPersonController;
    // Transform characterRoot;
    int characterIndex;

    void Awake() {
        // thirdPersonController = currentCharacter.GetComponent<ThirdPersonController>();
    }

    void Start() {
        characterIndex = 0;
        currentCharacter = characters[0];
    }

    void Update () {
        if(Input.GetButtonDown("Fire1")){
            characterIndex++;
            
            if(characterIndex == characters.Length){
                characterIndex = 0;
            };

            followCamera.GetComponent<CinemachineVirtualCamera>().LookAt = characters[characterIndex].transform.GetChild(0);
            followCamera.GetComponent<CinemachineVirtualCamera>().Follow = characters[characterIndex].transform.GetChild(0);

            // Console.WriteLine(currentCharacter);
            // currentCharacter.GetComponent<Animator>().enabled = false;
            currentCharacter.GetComponent<CharacterController>().enabled = false;
            // currentCharacter.GetComponent<ThirdPersonController>().enabled = false;
            currentCharacter.GetComponent<PlayerInput>().enabled = false;

            // characters[characterIndex].GetComponent<Animator>().enabled = true;
            characters[characterIndex].GetComponent<CharacterController>().enabled = true;
            // characters[characterIndex].GetComponent<ThirdPersonController>().enabled = true;
            characters[characterIndex].GetComponent<PlayerInput>().enabled = true;

            // characterRoot = characters[characterIndex].transform.GetChild(0);
            currentCharacter = characters[characterIndex];
        }
    }
}
