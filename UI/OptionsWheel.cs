﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsWheel : MonoBehaviour {

    public GameObject optionsMenu;
    private bool menuOpen;
    private string openScene;

	void Start () {
        menuOpen = optionsMenu.activeSelf;
        openScene = SceneManager.GetActiveScene().name;
    }
	

    public void ToggleOptionsMenu()
    {
        menuOpen = !menuOpen;
        optionsMenu.SetActive(menuOpen);
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