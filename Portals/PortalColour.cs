using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalColour : MonoBehaviour {
    public float time = 5f;

    private bool isCycling;
    private Material material;

    private void Awake()
    {
        isCycling = false;
        material = GetComponent<Renderer>().material;
        Color initialColor = GetRandomColor(material.GetColor("_Color"));
        material.SetColor("_Color", initialColor);
    }

    /// <summary>
    /// Sets a new colour target every cycle
    /// </summary>
    private void Update()
    {
        if (!isCycling)
        {
            Color startColor = material.GetColor("_Color");
            Color endColor = GetRandomColor(startColor);
            StartCoroutine(CycleMaterial(startColor, endColor, time));
        }
    }

    /// <summary>
    /// Gets a random bright and saturated colour
    /// </summary>
    /// <param name="startColor">Initial color</param>
    /// <returns> 
    /// A random color that likely (but not garaunteed to be) different from the initial color
    /// </returns>
    private Color GetRandomColor(Color startColor)
    {
        Color randomColor = Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.8f, 0.8f);
        if (randomColor.Equals(startColor))
        {
            randomColor = Random.ColorHSV();
        }

        return randomColor;
    }

    /// <summary>
    /// Transitions to a target color over cycleTime
    /// </summary>
    /// <param name="startColor">Initial color</param>
    /// <param name="endColor">Target color</param>
    /// <param name="cycleTime">Length of colour transition in seconds</param>
    private IEnumerator CycleMaterial(Color startColor, Color endColor, float cycleTime)
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
