using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Animator star;
    public Text score;

    private int maxScore = 99999999;

    private void Start()
    {
        score.text = "0";
    }

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

    public int GetCurrentScore()
    {
        return int.Parse(score.text);
    }
}
