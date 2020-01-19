using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //Singleton
    public static GameManager gameManager;

	private void Awake () {
		if (gameManager == null)
        {
            gameManager = this;
        } else if (gameManager != this)
        {
            Destroy(gameObject);
        }
	}

    /// <summary>
    /// Counts number of times Survival has been played and handles related achievements
    /// </summary>
    private void HandleTimesPlayedAchievement()
    {
        GameControl.timesPlayedSurvival++;

        switch (GameControl.timesPlayedSurvival)
        {
            case 10:
                GameControl.hungry = true;
                break;
            case 50:
                GameControl.famished = true;
                break;
            case 100:
                GameControl.ravenous = true;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Updates high score
    /// </summary>
    private void UpdateHighScore()
    {
        int currentScore = ReferenceManager.refManager.scoreManager.GetCurrentScore();
        if (currentScore > GameControl.highScoreSurvival)
        {
            GameControl.highScoreSurvival = currentScore;
        }
    }

    /// <summary>
    /// Ends game and handles game-over logic
    /// </summary>
    public void EndGame()
    {
        HandleTimesPlayedAchievement();
        UpdateHighScore();
        ReferenceManager.refManager.timeManager.EndGame();
        GameObject gameOverCanvas = ReferenceManager.refManager.gameOverCanvas;
        gameOverCanvas.SetActive(true);
        Animator gameOverCanvasAnim = gameOverCanvas.GetComponent<Animator>();
        gameOverCanvasAnim.SetTrigger("GameOver");
    }
}
