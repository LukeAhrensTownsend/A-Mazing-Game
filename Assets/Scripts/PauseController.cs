using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start() {
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
        MusicController.levelAudioSource.volume = 0.2f;
        isPaused = true;
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        MusicController.levelAudioSource.volume = 1f;
        isPaused = false;
    }

    public void MainMenu() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        PlayerController.isGameOver = false;
        PlayerController.isDead = false;
        MusicController.levelAudioSource.volume = 0f;
        MusicController.mainMenuAudioSource.volume = 1f;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
