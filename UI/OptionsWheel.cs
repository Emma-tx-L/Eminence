using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsWheel : MonoBehaviour {

    [Header("References")]
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject achievementsMenu;

    //Privates
    private bool menuOpen;
    private string openScene;

	private void Start () {
        menuOpen = optionsMenu.activeSelf;
        openScene = SceneManager.GetActiveScene().name;
    }
	
    /// <summary>
    /// Toggles Open Menu. While Menu is open, pauses game.
    /// </summary>
    public void ToggleOptionsMenu()
    {
        menuOpen = !menuOpen;
        optionsMenu.SetActive(menuOpen);

        if (!menuOpen && achievementsMenu)
        {
            achievementsMenu.SetActive(false);
        }

        if (openScene == "GameMode")
        {
            if (menuOpen)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
}
