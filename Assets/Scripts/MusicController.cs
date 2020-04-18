using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public GameObject mainMenuMusic;
    public GameObject levelMusic;
    public static AudioSource mainMenuAudioSource;
    public static AudioSource levelAudioSource;

    private static MusicController instance = null;

    void Awake()
    {
        mainMenuAudioSource = GameObject.FindGameObjectWithTag("MainMenuMusic").GetComponent<AudioSource>();
        levelAudioSource = GameObject.FindGameObjectWithTag("LevelMusic").GetComponent<AudioSource>();

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);

            mainMenuAudioSource.Play();
        }
    }

    public static void FadeInCaller(AudioSource audioSource, float fadeTime)
    {
        instance.StartCoroutine(FadeIn(audioSource, fadeTime));
    }

    public static void FadeOutCaller(AudioSource audioSource, float fadeTime)
    {
        instance.StartCoroutine(FadeOut(audioSource, fadeTime));
    }

    private static IEnumerator FadeIn(AudioSource audioSource, float fadeTime)
    {
        audioSource.Play();
        audioSource.volume = 0f;
        float audioVolume = audioSource.volume;

        while (audioSource.volume < 1.0f)
        {
            audioVolume += fadeTime;
            audioSource.volume = audioVolume;

            yield return new WaitForSeconds(0.1f);
        }
    }

    private static IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
    {
        float audioVolume = audioSource.volume;

        while (audioSource.volume > 0.0f)
        {
            audioVolume -= fadeTime;
            audioSource.volume = audioVolume;

            yield return new WaitForSeconds(0.1f);
        }

        audioSource.Pause();
    }

    public static void StopCoroutines()
    {
        instance.StopAllCoroutines();
    }
}