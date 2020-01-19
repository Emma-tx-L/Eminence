using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAnimations : MonoBehaviour {
    /// <summary>
    /// Wrapper for playing animations available for each Portal
    /// </summary>

    [Header("References")]
    [SerializeField] private ParticleSystem badSpark;
    [SerializeField] private ParticleSystem goodSpark;
    [SerializeField] private ParticleSystem badCue;
    [SerializeField] private ParticleSystem goodCue;

    public void cueBad()
    {
        badCue.Play();
    }

    public void cueGood()
    {
        goodCue.Play();
    }

    public void sparkBad()
    {
        badSpark.Play();
    }

    public void sparkGood()
    {
        goodSpark.Play();
    }

    /// <summary>
    /// Getter for bad blessings ParticleSystem
    /// </summary>
    /// <returns>Bad blessings ParticleSystem</returns>
    public ParticleSystem getBadSpark()
    {
        return badSpark;
    }

    /// <summary>
    /// Getter for good blessings ParticleSystem
    /// </summary>
    /// <returns>Good blessings ParticleSystem</returns>
    public ParticleSystem getGoodSpark()
    {
        return goodSpark;
    }
}
