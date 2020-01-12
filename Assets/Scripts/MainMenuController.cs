using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void NewGame() {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void LoadScene(int sceneIndex) {
        PlayerController.isGameOver = false;
        PlayerController.isDead = false;
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
