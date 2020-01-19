using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour {

    [Header("Settings")]
    [SerializeField, Range(1f, 5f)] private float speed = 3f;

	/// <summary>
    ///  Rotate the skybox over time
    /// </summary>
	void Update () {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);
    }
}
