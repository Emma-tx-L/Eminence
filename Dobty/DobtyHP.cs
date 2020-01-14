using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DobtyHP : MonoBehaviour {
    public float maxBrightness = 3f;
    public float minBrightness = 0.4f;

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
    private int gameMode;
    private ScoreManager scoreManager;
    private AudioManager audioManager;

    private void Awake() {
        material = GetComponentInChildren<Renderer>().material;
        currentHP = maxHP;
        iframed = false;
        gameMode = GameControl.gameMode;
        DobtyIconAnim = ReferenceManager.refManager.DobtyIconAnim;
        scoreManager = ReferenceManager.refManager.scoreManager;
        audioManager = ReferenceManager.refManager.audioManager;
        SetUpHPSlider();
    }

    private void SetUpHPSlider()
    {
        if (gameMode == 0)
        {
            HPSlider = ReferenceManager.refManager.HPSlider;
            HPSlider.maxValue = maxHP;
            HPSlider.minValue = 0;
            HPSlider.value = currentHP;
        }
        if (gameMode == 1)
        {
            ReferenceManager.refManager.HPSliderObject.SetActive(false);
        }
    }

    private void ChangeBrightness(bool positive)
    {
        float change = positive ? brightnessIncrement : -brightnessIncrement;
        float newBrightness = Mathf.Clamp(material.GetFloat("_Brightness") + change, minBrightness, maxBrightness);
        material.SetFloat("_Brightness", newBrightness);
    }

    private void HandleAchievements()
    {
        if (gameMode == 0)
        {
            if (currentHP == maxHP)
            {
                int currentScore = scoreManager.GetCurrentScore();
                if (currentScore > 10)
                {
                    GameControl.untainted = true;
                }
                if (currentScore > 25)
                {
                    GameControl.pure = true;
                }
                if (currentScore > 50)
                {
                    GameControl.sacred = true;
                }
            }
        }
        else if (gameMode == 1)
        {
            int currentScore = scoreManager.GetCurrentScore();
            if (currentScore > 50)
            {
                GameControl.worshipped = true;
            }
            if (currentScore > 100)
            {
                GameControl.revered = true;
            }
            if (currentScore > 200)
            {
                GameControl.exalted = true;
            }
        }
    }

    public void DeductHP(int deduction)
    {
        if (!iframed)
        {
            if (gameMode == 0)
            {
                currentHP = Mathf.Clamp(currentHP - deduction, 0, maxHP);
                if (currentHP <= 0)
                {
                    GameManager.gameManager.EndGame();
                    StartCoroutine(audioManager.PlayGameOver());
                }
                HPSlider.value = currentHP;
            }

            if (gameMode == 1)
            {
                scoreManager.UpdatePoints(scoreDecrement);
            }

            ChangeBrightness(false);
            badEffect.Play();
            DobtyIconAnim.SetTrigger("DobtyHurt");
            audioManager.PlaySad(false);
            StartCoroutine(MakeInvulnerable());
        }
    }

    public void AddHP(int addition)
    {
        if (!iframed)
        {
            ChangeBrightness(true);
            goodEffect.Play();
            scoreManager.UpdatePoints(scoreIncrement);
            DobtyIconAnim.SetTrigger("DobtyHappy");
            audioManager.PlayHappy(false);
            HandleAchievements();
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
