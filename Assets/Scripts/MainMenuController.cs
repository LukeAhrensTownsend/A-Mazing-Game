using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    
    public GameObject mainPanel;
    public GameObject levelSelectPanel;
    public GameObject controlsPanel;
    public GameObject Overlay;
    public GameController gameController;

    private static RawImage overlay = null;
    private static GameObject mainPanelInstance = null;

    public void Start() {
        if (overlay != null) {
            Destroy(gameObject);
        } else { 
            overlay = Overlay.GetComponent<RawImage>();
            mainPanelInstance = mainPanel;
            DontDestroyOnLoad(gameObject);
        }

        if (SceneManager.GetActiveScene().buildIndex == 0)
            mainPanelInstance.SetActive(true);
    }

    public void LoadMainMenuPanel(string panel = "main") {
        if (mainPanel) {
            mainPanel.SetActive(false);
            levelSelectPanel.SetActive(false);
            controlsPanel.SetActive(false);

            switch (panel) {
                case "levels":
                    levelSelectPanel.SetActive(true);
                    break;
                case "controls":
                    controlsPanel.SetActive(true);
                    break;
                default:
                    mainPanel.SetActive(true);
                    break;
            }
        }
    }

    public void LoadScene(int sceneIndex) {
        if (sceneIndex != 0) {
            MusicController.menuSelectAudioSource.Play();
            StartCoroutine(FadeToScene(sceneIndex, 0.01f));
        } else {
            gameController.LoadScene(sceneIndex);
        }
    }

    private IEnumerator FadeToScene(int sceneIndex, float fadeTime) {
        MusicController.FadeOutCaller(MusicController.mainMenuAudioSource, 0.1f);
        float alpha = overlay.color.a;

        while (overlay.color.a < 1.0f) {
            alpha += fadeTime;
            overlay.color = new Color(0f, 0f, 0f, alpha);

            yield return new WaitForSeconds(0.01f);
        }

        Cursor.visible = false;
        yield return new WaitForSeconds(1.0f);

        mainPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        controlsPanel.SetActive(false);
        gameController.LoadScene(sceneIndex);

        while (overlay.color.a > 0.0f) {
            alpha -= fadeTime;
            overlay.color = new Color(0f, 0f, 0f, alpha);

            yield return new WaitForSeconds(0.01f);
        }
    }

    public void QuitGame() {
        GameController.QuitGame();
    }
}
