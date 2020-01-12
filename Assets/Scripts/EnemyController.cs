using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;
    [Range(-1, 1)]
    public float initialHorizontal;
    [Range(-1, 1)]
    public float initialVertical;
   
    private Rigidbody rb;
    private Vector3 movement;  
    private float horizontalDirection;
    private float verticalDirection;

    void Start () {
        rb = GetComponent<Rigidbody>();
        horizontalDirection = initialHorizontal;
        verticalDirection = initialVertical;
	}
	
	void Update () {
        Move(horizontalDirection, verticalDirection);
    }

    void Move(float moveHorizontal, float moveVertical) {
        movement.Set(moveHorizontal, 0f, moveVertical);
        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    void OnTriggerEnter(Collider other) {
        switch (other.gameObject.tag) {
            case ("TriggerBoxUp"):
                TurnUp();
                break;

            case ("TriggerBoxRight"):
                TurnRight();
                break;

            case ("TriggerBoxDown"):
                TurnDown();
                break;

            case ("TriggerBoxLeft"):
                TurnLeft();
                break;
        }
    }

    void TurnUp() {
        horizontalDirection = 0f;
        verticalDirection = 1f;
    }

    void TurnRight() {
        horizontalDirection = 1f;
        verticalDirection = 0f;
    }

    void TurnDown() {
        horizontalDirection = 0f;
        verticalDirection = -1f;
    }

    void TurnLeft() {
        horizontalDirection = -1f;
        verticalDirection = 0f;
    }
}
