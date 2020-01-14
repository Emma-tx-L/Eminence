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
        SceneManager.LoadScene("LoadingScene");
    }

    public void LoadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LoadingScene");
    }
}
