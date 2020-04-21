using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour {
    
    public static MusicController instance = null;
    public GameObject mainMenuMusic;
    public GameObject levelMusic;
    public GameObject menuSelectSound;
    public static AudioSource mainMenuAudioSource;
    public static AudioSource levelAudioSource;
    public static AudioSource menuSelectAudioSource;

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            mainMenuAudioSource = mainMenuMusic.GetComponent<AudioSource>();
            levelAudioSource = levelMusic.GetComponent<AudioSource>();
            menuSelectAudioSource = menuSelectSound.GetComponent<AudioSource>();
            instance = this;
            DontDestroyOnLoad(gameObject);

            if (SceneManager.GetActiveScene().buildIndex == 0) {
                mainMenuAudioSource.Play();
            } else {
                levelAudioSource.Play();
            }
        }
    }

    private static IEnumerator FadeIn(AudioSource audioSource, float fadeTime) {
        if (audioSource) {
            audioSource.volume = 0f;
            float audioVolume = audioSource.volume;

            while (audioSource.volume < 1.0f) {
                audioVolume += fadeTime;
                audioSource.volume = audioVolume;

                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    private static IEnumerator FadeOut(AudioSource audioSource, float fadeTime) {
        if (audioSource) {
            float audioVolume = audioSource.volume;

            while (audioSource.volume > 0.0f) {
                audioVolume -= fadeTime;
                audioSource.volume = audioVolume;

                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public static void FadeInCaller(AudioSource audioSource, float fadeTime) {
        instance.StartCoroutine(FadeIn(audioSource, fadeTime));
    }

    public static void FadeOutCaller(AudioSource audioSource, float fadeTime) {
        instance.StartCoroutine(FadeOut(audioSource, fadeTime));
    }

    public static void StopCoroutines() {
        instance.StopAllCoroutines();
    }
}