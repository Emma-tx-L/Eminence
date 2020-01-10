using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameboardRotation : MonoBehaviour {
    public float time = 10f;
    bool isCycling;

    void Awake () {
        isCycling = false;
	}
	
	void Update () {
        if (!isCycling)
        {
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-5f, 5f);
            float z = Random.Range(-5f, 5f);
            StartCoroutine(CycleRotation(x, y, z, time));
        }
    }

    IEnumerator CycleRotation(float x, float y, float z, float cycleTime)
    {
        isCycling = true;
        float currentTime = 0;
        while (currentTime < cycleTime)
        {
            currentTime += Time.deltaTime;
            transform.Rotate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
            yield return null;
        }
        isCycling = false;
    }
}
