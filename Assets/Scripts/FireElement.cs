using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class FireElement : MonoBehaviour
{
    CharacterController controller;
    PlayerInput playerInput;

    public bool isInteracting;

    void Start() {
        isInteracting = false;
    }

    IEnumerator Interact()
    {   
        yield return new WaitForSeconds(5);
        isInteracting = false;
    }

    private void Awake() {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

   private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Water>() != null) {
            playerInput.enabled = false;
            controller.enabled = false;
            transform.position = other.GetComponent<Water>().spawnPoint.transform.position;
            GameManager.instance.UpdateGameState(GameState.GameOver);

            playerInput.enabled = true;
            controller.enabled = true;
        }

        if (other.GetComponent<Poison>() != null) {
            playerInput.enabled = false;
            controller.enabled = false;
            transform.position = other.GetComponent<Poison>().spawnPoint.transform.position;
            GameManager.instance.UpdateGameState(GameState.GameOver);

            playerInput.enabled = true;
            controller.enabled = true;
        }
    }

    void Update() {
        if(Input.GetButtonDown("Interact")){
            isInteracting = true;
            StartCoroutine(Interact());
        }
    }

}
