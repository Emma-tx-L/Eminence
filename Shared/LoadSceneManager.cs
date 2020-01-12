using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour {

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void GoToRetry()
    {
        Time.timeScale = 1f;
        Scene currentMap = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentMap.name);
    }

    public void LoadGame()
    {
        Time.timeScale = 1f;
        Debug.Log("loading game mode " + GameControl.gameMode);
        SceneManager.LoadScene("GameMode");
    }
}
