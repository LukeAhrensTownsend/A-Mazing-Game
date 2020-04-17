using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour {

    public GameObject mainMenuMusic;
    public GameObject levelMusic;
    public static AudioSource mainMenuAudioSource;
    public static AudioSource levelAudioSource;
    
    private static MusicController instance;
    private static string playing;

    void Awake() {
        mainMenuAudioSource = mainMenuMusic.GetComponent<AudioSource>();
        levelAudioSource = levelMusic.GetComponent<AudioSource>();

        if (instance != null) {
            Destroy(this.gameObject);
        } else {
            if (SceneManager.GetActiveScene().buildIndex < 3) {           
                mainMenuAudioSource.Play();
            } else {
                levelAudioSource.Play();
            }

            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
