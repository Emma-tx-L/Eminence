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

    /// <summary>
    /// 
    /// </summary>
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

    /// <summary>
    /// If Survival Mode, sets up HPSlider UI Component 
    /// If Endless Mode, deactivates HPSlider UI Component
    /// </summary>
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

    /// <summary>
    /// Changes Dobty's material's brightness property 
    /// </summary>
    /// <param name="positive">True if the change is positive, false if negative</param>
    private void ChangeBrightness(bool positive)
    {
        float change = positive ? brightnessIncrement : -brightnessIncrement;
        float newBrightness = Mathf.Clamp(material.GetFloat("_Brightness") + change, minBrightness, maxBrightness);
        material.SetFloat("_Brightness", newBrightness);
    }

    /// <summary>
    /// Check if achievements have been met based on current score, HP, and game mode
    /// </summary>
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

    /// <summary>
    /// If Survival mode, deduct HP, update HPSlider UI and call GameOver if HP <= 0
    /// If Endless mode, decrement points 
    /// Handles negative effects and calls iFrame
    /// </summary>
    /// <param name="deduction">Int value of HP or points to deduct</param>
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

    /// <summary>
    /// Update points
    /// Handles positive  effects and calls iFrame
    /// </summary>
    /// <param name="addition">Int value of HP or points to add</param>
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

    /// <summary>
    /// Make Dobty unable to gain/lose points/HP for iframed seconds
    /// </summary>
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
