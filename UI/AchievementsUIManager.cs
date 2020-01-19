using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AchievementsUIManager : MonoBehaviour {

    [Header("References")]
    [SerializeField] private GameObject AchievementsPanel;

    /// <summary>
    /// Opens Achievements menu
    /// </summary>
    public void OpenAchievements()
    {
        AchievementsPanel.SetActive(true);
    }

    /// <summary>
    /// Closes Achievements menu
    /// </summary>
    public void CloseAchievements()
    {
        AchievementsPanel.SetActive(false);
    }
}
