using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AchievementsUIManager : MonoBehaviour {

    public GameObject AchievementsPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenAchievements()
    {
        AchievementsPanel.SetActive(true);
    }

    public void CloseAchievements()
    {
        AchievementsPanel.SetActive(false);
    }
}
