using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToRetry()
    {
        Scene currentMap = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentMap.name);
    }

    public void LoadLightSurvivalMode()
    {
        SceneManager.LoadScene("LightModeSurvival");
    }
}
