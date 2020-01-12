using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGroundController : MonoBehaviour {

    private GameObject player;
    private Rigidbody playerRb;
    private Vector3 movementDirection;
    private Vector3 previousDirection;
    private Vector3 movement;
    
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Player")) {
            movementDirection = player.transform.InverseTransformDirection(playerRb.velocity);
            PlayerController.isSliding = true;  
        }
    }

    void OnCollisionStay(Collision col) {
        if (col.gameObject.CompareTag("Player")) {
            movementDirection = movementDirection.normalized * PlayerController.speed * Time.deltaTime;
            playerRb.MovePosition(player.transform.position + movementDirection);
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject.CompareTag("Player")) {
            PlayerController.isSliding = false;
        }
    }
}
