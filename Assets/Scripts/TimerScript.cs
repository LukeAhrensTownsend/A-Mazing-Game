using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

    public GameController gameControllerScript;
    public static float timeElapsed;

    private Text timerText;

    // Start is called before the first frame update
    void Start() {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        if (GameController.sceneIndex != 0) {
            if (!PlayerController.isGameOver) {
                timeElapsed = Time.timeSinceLevelLoad;
                timerText.text = "Level " + (gameControllerScript.GetSceneIndex() - 2) + 
                    "\n" + timeElapsed.ToString("F2");
            }
        }
    }
}
