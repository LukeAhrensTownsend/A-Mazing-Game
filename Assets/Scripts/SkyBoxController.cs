using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyBoxController : MonoBehaviour
{

    public Material[] skyboxes;

    private float skyboxRotateSpeed = 0.6f;

    void Awake() {
        RenderSettings.skybox = skyboxes[Random.Range(0, (skyboxes.Length - 1))];
        gameObject.transform.rotation = Random.rotation;
        skyboxRotateSpeed = 1f;
    }

    void LateUpdate() {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxRotateSpeed);
    }
}
