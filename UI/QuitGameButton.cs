using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGameButton : MonoBehaviour {

    [Header("References")]
    [SerializeField] private GameObject confirmPanel;

    /// <summary>
    /// Refuse to return to main menu. Hides confirmation box.
    /// </summary>
    public void ConfirmNo()
    {
        confirmPanel.SetActive(false);
    }

    /// <summary>
    /// Opens confirmation box
    /// </summary>
    public void OpenConfirm()
    {
        confirmPanel.SetActive(true);
    }

    /// <summary>
    /// Returns to main menu.
    /// If Endless mode, updates high score.
    /// </summary>
    public void ConfirmQuit()
    {
        if (GameControl.gameMode == 1)
        {
            int currentScore = ReferenceManager.refManager.scoreManager.GetCurrentScore();
            if (currentScore > GameControl.highScoreEndless)
            {
                GameControl.highScoreEndless = currentScore;
            }
        }
        ReferenceManager.refManager.loadSceneManager.GoToMainMenu();
    }
}
