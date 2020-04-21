using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyBoxController : MonoBehaviour {

    private float skyboxRotateSpeed = 0.6f;

    void Awake() {
        gameObject.transform.rotation = Random.rotation;
        skyboxRotateSpeed = 1f;
    }

    void LateUpdate() {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxRotateSpeed);
    }
}
