using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameboardRotation : MonoBehaviour {

    [Header("Settings")]
    [SerializeField, Range(5, 30)] private float time = 10f;

    //Privates
    private bool isCycling;

    private void Awake () {
        isCycling = false;
	}
	
	private void Update () {
        if (!isCycling)
        {
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-5f, 5f);
            float z = Random.Range(-5f, 5f);
            StartCoroutine(CycleRotation(x, y, z, time));
        }
    }

    /// <summary>
    /// Rotate x, y, and z angles per second for cycleTime seconds
    /// </summary>
    /// <param name="x">xAngles to rotate per second</param>
    /// <param name="y">yAngles to rotate per second</param>
    /// <param name="z">zAngles to rotate per second</param>
    /// <param name="cycleTime">Length of time in seconds to rotate</param>
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
