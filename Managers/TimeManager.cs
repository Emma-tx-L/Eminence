﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    /// <summary>
    /// Lerps timeScale from start to end time over given interval
    /// </summary>
    /// <param name="start">Start timeScale</param>
    /// <param name="start">Target timeScale</param>
    /// <param name="start">Time in real seconds over which the change occurs</param>
    private IEnumerator ScaleTime(float start, float end, float time)
    {
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        while (timer < time)
        {
            Time.timeScale = Mathf.Lerp(start, end, timer / time);
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }

        Time.timeScale = end;
    }

    /// <summary>
    /// Slowly stop game time when game over
    /// </summary>
    public void EndGame()
    {
        StartCoroutine(ScaleTime(1f, 0f, 1f));
    }
}
