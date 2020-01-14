using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalActions : MonoBehaviour {
    public float medianInterval = 8f;
    public int points = 2;
    public int damage = 2;

    private ParticleSystem goodSpark;
    private ParticleSystem badSpark;

    private float openingInterval;
    private bool playerInRange;

    private Animator anim;
    private float timer;

	private void Start () {
        anim = GetComponent<Animator>();
        goodSpark = GetComponent<PortalAnimations>().goodSpark;
        badSpark = GetComponent<PortalAnimations>().badSpark;
        ResetTimer();
        SetNeutral();
	}

	private void Update () {
        CycleActions();
	}

    /// <summary>
    /// Randomly choose good or bad blessings to go through Portal every openingInterval seconds
    /// </summary>
    private void CycleActions()
    {
        if (timer >= openingInterval)
        {
            int fate = Random.Range(0, 2); //returns 0 or 1
            if (fate == 0)
            {
                SetBad();
            }
            else
            {
                SetGood();
            }
            ResetTimer();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    /// <summary>
    /// Resets opening interval timer to 0
    /// Randomize opening interval within 3 seconds of the fixed median
    /// </summary>
    private void ResetTimer()
    {
        timer = 0f;
        openingInterval = Random.Range(medianInterval - 3, medianInterval + 3);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<DobtyHP>() != null)
        {
            //A Portal's good/bad state is defined by which particle effect is playing
            bool isGood = goodSpark.isPlaying;
            bool isBad = badSpark.isPlaying;

            if (isGood && !isBad)
            {
                other.gameObject.GetComponent<DobtyHP>().AddHP(points);
            }
            else if (!isGood && isBad)
            {
                other.gameObject.GetComponent<DobtyHP>().DeductHP(damage);
            }
        }
    }

    /// <summary>
    /// Ensures Portal enters neutal state
    /// </summary>
    public void SetNeutral()
    {
        anim.ResetTrigger("isBad");
        anim.ResetTrigger("isGood");
    }

    /// <summary>
    /// Opens Portal with a bad blessing
    /// </summary>
    public void SetBad()
    {
        anim.SetTrigger("isBad");
    }

    /// <summary>
    /// Opens Portal with a good blessing
    /// </summary>
    public void SetGood()
    {
        anim.SetTrigger("isGood");
    }
}
