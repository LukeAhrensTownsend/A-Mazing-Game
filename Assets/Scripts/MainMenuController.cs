using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private static AudioSource mainMenuAudioSource;
    private static AudioSource levelAudioSource;

    void Awake() {
        mainMenuAudioSource = MusicController.mainMenuAudioSource;
        levelAudioSource = MusicController.levelAudioSource;
    }

    public void NewGame() {
        LoadScene(3);
    }

    public void LoadScene(int sceneIndex) {
        PlayerController.isGameOver = false;
        PlayerController.isDead = false;

        if (sceneIndex > 2) {
            MusicController.StopCoroutines();
            MusicController.FadeOutCaller(mainMenuAudioSource, 0.05f);
            MusicController.FadeInCaller(levelAudioSource, 0.01f);
        } else {
            MusicController.FadeOutCaller(levelAudioSource, 0.05f);
        }
        
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public void LevelSelect() {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Controls() {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
