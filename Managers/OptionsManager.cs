﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {
    public GameObject darkTheme;
    public GameObject lightTheme;

    public GameObject[] gameModes;

    public Text highScoreText;
    public Text currentScoreText;

    public Text survivalHighScore;
    public Text endlessHighScore;

    private string openScene;

	private void Start() {
        openScene = SceneManager.GetActiveScene().name;
        UpdateOptionsTheme();

        if (openScene == "MainMenu")
        {
            UpdateGameMode();
            UpdateHighScoreMenu();
        }
        else if (openScene == "GameMode")
        {
            UpdateHighScore();
            UpdateCurrentScore();
        }
    }

    private void OnEnable()
    {
        if (openScene == "GameMode")
        {
            UpdateCurrentScore();
        }
    }

    private void UpdateOptionsTheme()
    {
        if (GameControl.lightMode)
        {
            lightTheme.SetActive(true);
            darkTheme.SetActive(false);
        }
        else
        {
            lightTheme.SetActive(false);
            darkTheme.SetActive(true);
        }
    }

    private void UpdateGameMode()
    {
        foreach (GameObject mode in gameModes)
        {
            mode.SetActive(false);
        }
        gameModes[GameControl.gameMode].SetActive(true);
    }

    public void ChangeGameMode()
    {
        int currentMode = GameControl.control.getGameMode();
        int nextMode = (currentMode == gameModes.Length - 1) ? 0 : currentMode + 1;

        gameModes[currentMode].SetActive(false);
        gameModes[nextMode].SetActive(true);

        GameControl.control.setGameMode(nextMode);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void UpdateCurrentScore()
    {
        int currentScore = ReferenceManager.refManager.scoreManager.GetCurrentScore();
        currentScoreText.text = currentScore.ToString();
    }

    public void UpdateHighScore()
    {
        switch (GameControl.gameMode)
        {
            case 0:
                highScoreText.text = GameControl.highScoreSurvival.ToString();
                break;
            case 1:
                highScoreText.text = GameControl.highScoreEndless.ToString();
                break;
            default:
                highScoreText.text = "0";
                break;
        }
    }

    public void UpdateHighScoreMenu()
    {
        survivalHighScore.text = GameControl.highScoreSurvival.ToString();
        endlessHighScore.text = GameControl.highScoreEndless.ToString();
    }

    public void ChangeTheme()
    {
        GameControl.control.toggleThemePreference();
        UpdateOptionsTheme();
        ReferenceManager.refManager.theme.UpdateColourTheme();
        EventSystem.current.SetSelectedGameObject(null);
    }

}
