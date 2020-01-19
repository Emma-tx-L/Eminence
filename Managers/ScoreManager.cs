using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    [Header("References")]
    [SerializeField] private Animator star;
    [SerializeField] private Text score;

    //Privates
    private int maxScore = 99999999;

    private void Start()
    {
        score.text = "0";
    }

    /// <summary>
    /// Update current score UI and animates Star
    /// </summary>
    /// <param name="amount">Amount to change score by</param>
    public void UpdatePoints(int amount)
    {
        int currentScore = int.Parse(score.text);
        currentScore = Mathf.Clamp(currentScore + amount, 0, maxScore);
        score.text = currentScore.ToString();
        if (amount > 0)
        {
            star.SetTrigger("AddPoints");
        }
        else
        {
            star.SetTrigger("LosePoints");
        }
    }

    /// <summary>
    /// Gets current score from score UI
    /// </summary>
    public int GetCurrentScore()
    {
        return int.Parse(score.text);
    }
}
