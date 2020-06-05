using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject mainPanel;
    public GameObject controlsPanel;
    public GameController gameController;
    public static bool isPaused;

    private AudioSource levelAudioSource;

    // Start is called before the first frame update
    void Start() {
        levelAudioSource = GameObject.FindGameObjectWithTag("LevelMusic").GetComponent<AudioSource>();
        isPaused = false;
    }

    // Update is called once per frame
    void Update() {
        if (!PlayerController.isGameOver && Input.GetKeyDown(KeyCode.Escape)) {
            if (!isPaused) {
                Pause();
            } else {
                Resume();
            }
        }
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        levelAudioSource.volume = 0.2f;
        isPaused = true;
        Cursor.visible = true;
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        levelAudioSource.volume = 1f;
        isPaused = false;
        Cursor.visible = false;
    }

    public void LoadPauseMenuPanel(string panel = "main") {
        if (mainPanel) {
            mainPanel.SetActive(false);
            controlsPanel.SetActive(false);

            switch (panel) {
                case "controls":
                    controlsPanel.SetActive(true);
                    break;
                default:
                    mainPanel.SetActive(true);
                    break;
            }
        }
    }

    public void LoadMainMenu() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        gameController.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
