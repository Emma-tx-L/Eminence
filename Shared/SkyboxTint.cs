using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxTint : MonoBehaviour {
    public float time = 5f;
    bool isCycling;

    void Awake () {
        isCycling = false;
    }
	
	void Update () {
        if (!isCycling)
        {
            Color startColor = RenderSettings.skybox.GetColor("_Tint");
            Color endColor = Random.ColorHSV(0f, 1f, 0.1f, 0.1f,0.7f, 0.7f);
            if (endColor.Equals(startColor))
            {
                endColor = Random.ColorHSV();
            }
            StartCoroutine(CycleMaterial(startColor, endColor, time));
        }
    }

    IEnumerator CycleMaterial(Color startColor, Color endColor, float cycleTime)
    {
        isCycling = true;
        float currentTime = 0;
        while (currentTime < cycleTime)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / cycleTime;
            Color currentColor = Color.Lerp(startColor, endColor, t);
            RenderSettings.skybox.SetColor("_Tint", currentColor);
            yield return null;
        }
        isCycling = false;
    }

}
