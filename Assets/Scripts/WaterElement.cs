using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class WaterElement : MonoBehaviour
{
    CharacterController controller;
    PlayerInput playerInput;

    private void Awake() {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

   private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Lava>() != null) {
            playerInput.enabled = false;
            controller.enabled = false;
            transform.position = other.GetComponent<Lava>().spawnPoint.transform.position;

            playerInput.enabled = true;
            controller.enabled = true;
        }

        if (other.GetComponent<Poison>() != null) {
            playerInput.enabled = false;
            controller.enabled = false;
            transform.position = other.GetComponent<Poison>().spawnPoint.transform.position;

            playerInput.enabled = true;
            controller.enabled = true;
        }
    }

}
