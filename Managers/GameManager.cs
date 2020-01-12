using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

	void Awake () {
		if (gameManager == null)
        {
            gameManager = this;
        } else if (gameManager != this)
        {
            Destroy(gameObject);
        }
	}

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

    private void UpdateHighScore()
    {
        int currentScore = ReferenceManager.refManager.scoreManager.GetCurrentScore();
        if (currentScore > GameControl.highScoreSurvival)
        {
            GameControl.highScoreSurvival = currentScore;
        }
    }
	

    public void EndGame()
    {
        HandleTimesPlayedAchievement();
        ReferenceManager.refManager.timeManager.EndGame();
        GameObject gameOverCanvas = ReferenceManager.refManager.gameOverCanvas;
        gameOverCanvas.SetActive(true);
        Animator gameOverCanvasAnim = gameOverCanvas.GetComponent<Animator>();
        gameOverCanvasAnim.SetTrigger("GameOver");
    }
}
