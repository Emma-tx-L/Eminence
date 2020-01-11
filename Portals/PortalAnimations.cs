using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAnimations : MonoBehaviour {
    public ParticleSystem badCue;
    public ParticleSystem goodCue;
    public ParticleSystem badSpark;
    public ParticleSystem goodSpark;

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
}
