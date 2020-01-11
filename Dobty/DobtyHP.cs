using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DobtyHP : MonoBehaviour {
    public float maxBrightness = 3f;
    public float minBrightness = 0.5f;

    public int maxHP = 10;
    public int currentHP;

    public int scoreIncrement = 1;
    public int scoreDecrement = -2;

    public ParticleSystem goodEffect;
    public ParticleSystem badEffect;

    private Slider HPSlider;
    private Animator DobtyIconAnim;
    private float brightnessIncrement = 0.1f;
    private float iframe = 0.5f;
    private bool iframed;
    private Material material;

    void Start () {
        material = GetComponentInChildren<Renderer>().material;
        currentHP = maxHP;
        iframed = false;
        SetUpHPSlider();
    }

    private void SetUpHPSlider()
    {
        HPSlider = ReferenceManager.refManager.HPSlider;
        DobtyIconAnim = ReferenceManager.refManager.DobtyIconAnim;
        HPSlider.maxValue = maxHP;
        HPSlider.minValue = 0;
        HPSlider.value = currentHP;
    }

    private void ChangeBrightness(bool positive)
    {
        float change = positive ? brightnessIncrement : -brightnessIncrement;
        float newBrightness = Mathf.Clamp(material.GetFloat("_Brightness") + change, minBrightness, maxBrightness);
        material.SetFloat("_Brightness", newBrightness);
    }

    public void DeductHP(int deduction)
    {
        if (!iframed)
        {
            currentHP = Mathf.Clamp(currentHP - deduction, 0, maxHP);
            if (currentHP <= 0)
            {
                GameManager.gameManager.EndGame();
            }
            ChangeBrightness(false);
            badEffect.Play();
            //ReferenceManager.refManager.scoreManager.UpdatePoints(scoreDecrement);
            DobtyIconAnim.SetTrigger("DobtyHurt");
            HPSlider.value = currentHP;
            StartCoroutine(MakeInvulnerable());
        }
    }

    public void AddHP(int addition)
    {
        if (!iframed)
        {
            //currentHP = Mathf.Clamp(currentHP + addition, 0, maxHP);
            ChangeBrightness(true);
            goodEffect.Play();
            ReferenceManager.refManager.scoreManager.UpdatePoints(scoreIncrement);
            DobtyIconAnim.SetTrigger("DobtyHappy");
            HPSlider.value = currentHP;
            StartCoroutine(MakeInvulnerable());
        }
    }

    public IEnumerator MakeInvulnerable()
    {
        iframed = true;
        float currentTime = 0;
        while (currentTime < iframe)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
        iframed = false;
    }
}
