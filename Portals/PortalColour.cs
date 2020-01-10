using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalColour : MonoBehaviour {
    public float time = 5f;
    bool isCycling;
    Material material;

    void Awake()
    {
        isCycling = false;
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (!isCycling)
        {
            Color startColor = material.GetColor("_Color");
            Color endColor = Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.8f, 0.8f);
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
            material.SetColor("_Color", currentColor);
            //material.SetColor("_MKGlowTexColor", currentColor);
            yield return null;
        }
        isCycling = false;
    }
}
