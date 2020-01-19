using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxTint : MonoBehaviour {
    
    [Header("Settings")]
    [SerializeField, Range(1f, 10f)] private float time = 5f;

    //Privates
    private bool isCycling;

    private void Awake () {
        isCycling = false;
    }
	
	private void Update () {
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

    /// <summary>
    ///  Transitions from startColor to endColor over cycleTime seconds
    /// </summary>
    /// <param name="startColor">The initial colour</param>
    /// <param name="endColor">The target colour</param>
    /// <param name="cycleTime">The time interval of colour change in seconds</param>
    /// <returns></returns>
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
