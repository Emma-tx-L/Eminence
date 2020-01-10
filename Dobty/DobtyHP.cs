using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DobtyHP : MonoBehaviour {
    public float maxBrightness = 3f;
    public float minBrightness = 0.5f;

    Material material;

    // Use this for initialization
    void Start () {
        material = GetComponentInChildren<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator CycleBrightness(float initial, float target, float cycleTime)
    {
        //isCycling = true;
        float currentTime = 0;
        while (currentTime < cycleTime)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / cycleTime;
            float currentBrightness = Mathf.Lerp(initial, target, t);
            material.SetFloat("_Brightness", currentBrightness);
            yield return null;
        }
        //isCycling = false;
    }
}
