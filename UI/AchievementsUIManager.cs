using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AchievementsUIManager : MonoBehaviour {

    public GameObject AchievementsPanel;

    public void OpenAchievements()
    {
        AchievementsPanel.SetActive(true);
    }

    public void CloseAchievements()
    {
        AchievementsPanel.SetActive(false);
    }
}
