using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour {

    /// <summary>
    /// Unpause and Load Main Menu
    /// </summary>
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Unpause and load the loading scene, which will handle game scene loading
    /// </summary>
    public void GoToRetry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LoadingScene");
    }

    /// <summary>
    /// Unpause and load the loading scene, which will handle game scene loading
    /// </summary>
    public void LoadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LoadingScene");
    }
}
