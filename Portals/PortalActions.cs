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

	void Start () {
        anim = GetComponent<Animator>();
        goodSpark = GetComponent<PortalAnimations>().goodSpark;
        badSpark = GetComponent<PortalAnimations>().badSpark;
        ResetTimer();
        SetNeutral();
	}
	
	void Update () {
        CycleActions();
	}

    private void CycleActions()
    {
        if (timer >= openingInterval)
        {
            int fate = Random.Range(0, 2);
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

    private void ResetTimer()
    {
        timer = 0f;
        openingInterval = Random.Range(medianInterval - 3, medianInterval + 3);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<DobtyHP>() != null)
        {
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

    public void SetNeutral()
    {
        anim.ResetTrigger("isBad");
        anim.ResetTrigger("isGood");
    }

    public void SetBad()
    {
        anim.SetTrigger("isBad");
    }

    public void SetGood()
    {
        anim.SetTrigger("isGood");
    }
}
