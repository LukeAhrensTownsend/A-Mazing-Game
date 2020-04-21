using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public static float speed;
    public static bool isGameOver;
    public static bool isDead;
    public static bool isSliding;
    
    private GameObject gameController;
    private GameController gameControllerScript;
    private Rigidbody rb;
    private int score;
    private int collectibleAmount;

    void Start() {
        rb = GetComponent<Rigidbody>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
        speed = 10f;
        isGameOver = false;
        isDead = false;
        isSliding = false;
        score = 0;
        collectibleAmount = GameObject.FindGameObjectsWithTag("Collectible").Length;
    }

    void FixedUpdate() {

        // Get user input for player's movement.
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Simple player movement.
        if (!isSliding && !isGameOver) {
            rb.velocity = new Vector3(moveHorizontal, 0f, moveVertical) * speed;
        } else {
            rb.velocity = new Vector3(0f, 0f, 0f) * speed;
        }
    }

    void OnTriggerEnter(Collider other) {

        // Colliding with a collectible.
        if (other.gameObject.CompareTag("Collectible")) {
            other.gameObject.SetActive(false);
            score++;
        }

        // Colliding with an enemy.
        if (other.gameObject.CompareTag("Enemy")) {
            gameObject.SetActive(false);
            isGameOver = true;
            isDead = true;

            gameControllerScript.LoadGameOverMessage();
        }

        // Colliding with the finish area.
        if (other.gameObject.CompareTag("TriggerBoxFinish")) {
            if (score >= collectibleAmount) {
                isGameOver = true;

                gameControllerScript.LoadGameOverMessage();
            }
        }
    }

    // Accessor methods...
    public float GetSpeed() {
        return speed;
    }
}
