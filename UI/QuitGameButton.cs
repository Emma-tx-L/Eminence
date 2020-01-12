using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGameButton : MonoBehaviour {

    public GameObject confirmPanel;

    public void ConfirmNo()
    {
        confirmPanel.SetActive(false);
    }

    public void OpenConfirm()
    {
        confirmPanel.SetActive(true);
    }

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
