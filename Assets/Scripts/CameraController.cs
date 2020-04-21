using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

    private GameObject player;
    private float playerPositionX;
    private float playerPositionZ;
    private Vector3 offset;
    private Vector3 zoomedOutPosition;
    private bool zoomedOut;
    private bool testBool;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player) {
            playerPositionX = player.transform.position.x;
            playerPositionZ = player.transform.position.z;

            transform.position = new Vector3(playerPositionX, 20f, playerPositionZ);

            offset = transform.position - player.transform.position;
            zoomedOut = testBool = false;
        }   

        switch (SceneManager.GetActiveScene().buildIndex) {
            case 1: zoomedOutPosition = new Vector3(0, 20, 0);
                break;
            case 2: zoomedOutPosition = new Vector3(0, 20, 0);
                break;
        }
	}
	
	void LateUpdate () {
        DisplayZoom();
        CheckInput();
	}

    void DisplayZoom() {
        if (zoomedOut) {
            transform.position = zoomedOutPosition;
        } else {
            if (player)
                transform.position = player.transform.position + offset;
        }
    }

    void CheckInput() {
        if (Input.GetKeyDown(KeyCode.Minus)) {
            zoomedOut = true;
            testBool = true;
        }

        if (Input.GetKeyDown(KeyCode.Equals)) {
            zoomedOut = false;
            testBool = false;
        }

        if (Input.GetKey(KeyCode.Space)) {
            if (testBool) {
                zoomedOut = false;
            } else {
                zoomedOut = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            if (testBool) {
                zoomedOut = true;
            } else {
                zoomedOut = false;
            }
        }
    }
}
