using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

    public static float timeElapsed;

    private Text timerText;
    private int sceneIndex;

    // Start is called before the first frame update
    void Start() {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        if (sceneIndex != 0) {
            if (!PlayerController.isGameOver) {
                timeElapsed = Time.timeSinceLevelLoad;
                timerText.text = "Level " + sceneIndex + 
                    "\n" + timeElapsed.ToString("F2");
            }
        }
    }
}
