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
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }

    public void GoToRetry()
    {
        Scene currentMap = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentMap.name, LoadSceneMode.Additive);
    }
}
