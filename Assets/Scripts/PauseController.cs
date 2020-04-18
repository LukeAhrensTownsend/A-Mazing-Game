using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public MainMenuController mainMenuController;
    public static bool isPaused;

    private static AudioSource mainMenuAudioSource;
    private static AudioSource levelAudioSource;

    void Awake() {
        mainMenuAudioSource = MusicController.mainMenuAudioSource;
        levelAudioSource = MusicController.levelAudioSource;
    }

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
        levelAudioSource.volume = 0.2f;
        isPaused = true;
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        levelAudioSource.volume = 1f;
        isPaused = false;
    }

    public void LoadSceneFromPause(int sceneIndex) {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        PlayerController.isGameOver = false;
        PlayerController.isDead = false;
        MusicController.StopCoroutines();
        MusicController.FadeInCaller(mainMenuAudioSource, 0.05f);
        mainMenuController.LoadScene(sceneIndex);
    }

    public void LoadNextScene() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene < 3) {
            SceneManager.LoadScene((currentScene + 1), LoadSceneMode.Single);
        } else {
            LoadSceneFromPause(1);
        }
    }

    public void QuitGame() {
        Application.Quit();
    }
}
