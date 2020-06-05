using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject LevelCompleteUI;
    public GameObject YouDiedUI;
    public GameObject LevelCompleteTimerText;
    public MusicController musicController;
    public static int maxScenes;

    private GameObject player;
    private GameObject finishArea;
    private GameObject triggerBoxFinish;
    private PlayerController playerControllerScript;
    private AudioSource mainMenuAudioSource;
    private AudioSource levelAudioSource;
    private int sceneIndex;

    void Awake() {
        mainMenuAudioSource = musicController.mainMenuMusic.GetComponent<AudioSource>();
        levelAudioSource = musicController.levelMusic.GetComponent<AudioSource>();
    }

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        finishArea = GameObject.FindGameObjectWithTag("FinishArea");
        triggerBoxFinish = GameObject.FindGameObjectWithTag("TriggerBoxFinish");
        playerControllerScript = player.GetComponent<PlayerController>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        maxScenes = SceneManager.sceneCountInBuildSettings - 1;

        // Sets the 'Trigger Box (Finish)' position/scale relative to the 'Finish Area'.
        triggerBoxFinish.transform.position = new Vector3(finishArea.transform.position.x, 0.5f, finishArea.transform.position.z);
        triggerBoxFinish.transform.localScale = new Vector3(Mathf.Abs(finishArea.transform.localScale.x - 2.6f), 1f, Mathf.Abs(finishArea.transform.localScale.z - 2.6f));

        LevelCompleteUI.SetActive(false);
        YouDiedUI.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (PlayerController.isGameOver) {
            CheckInput();             
        }
	}

    void CheckInput() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (PlayerController.isDead) {
                ReloadScene();
            } else {
                if ((sceneIndex + 1) < SceneManager.sceneCount) {
                    LoadScene(0);
                } else {
                    LoadNextScene();
                }
            }
        }
    }

    public void LoadScene(int sceneIndex) {
        PlayerController.isGameOver = false;
        PlayerController.isDead = false;

        MusicController.StopCoroutines();
        if (sceneIndex != 0) {
            MusicController.levelAudioSource.Play();
            MusicController.FadeOutCaller(MusicController.mainMenuAudioSource, 0.05f);
            MusicController.FadeInCaller(MusicController.levelAudioSource, 0.01f);
        } else {
            MusicController.FadeOutCaller(MusicController.levelAudioSource, 0.05f);
            MusicController.FadeInCaller(MusicController.mainMenuAudioSource, 0.05f);
        }
        
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public void ReloadScene() {
        PlayerController.isGameOver = false;
        PlayerController.isDead = false;

        YouDiedUI.SetActive(false);
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public void LoadNextScene() {
        if (sceneIndex < GameController.maxScenes) {
            SceneManager.LoadScene((sceneIndex + 1), LoadSceneMode.Single);
        } else {
            LoadScene(0);
        }
    }

    public void LoadGameOverMessage() {
        Cursor.visible = true;
        if (!PlayerController.isDead) {
            LevelCompleteTimerText.GetComponent<Text>().text = "Time: " + TimerScript.timeElapsed.ToString("F2");
            LevelCompleteUI.SetActive(true);
        } else {
            YouDiedUI.SetActive(true);
        }
    }

    public static void QuitGame() {
        Application.Quit();
    }
}
