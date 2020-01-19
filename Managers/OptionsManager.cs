using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

    [Header("Required References")]
    [SerializeField] private GameObject darkTheme;
    [SerializeField] private GameObject lightTheme;

    [Header("Main Menu References")]
    [SerializeField] private GameObject[] gameModes;
    [SerializeField] private Text survivalHighScore;
    [SerializeField] private Text endlessHighScore;

    [Header("Game Mode References")]
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text currentScoreText;

    //Privates
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

    /// <summary>
    /// Updates Light/Dark theme sprite UI
    /// </summary>
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

    /// <summary>
    /// Toggles colour theme
    /// </summary>
    public void ChangeTheme()
    {
        GameControl.control.toggleThemePreference();
        UpdateOptionsTheme();
        ReferenceManager.refManager.theme.UpdateColourTheme();
        EventSystem.current.SetSelectedGameObject(null);
    }

    /// <summary>
    /// Updates game mode UI
    /// Main Menu only
    /// </summary>
    private void UpdateGameMode()
    {
        foreach (GameObject mode in gameModes)
        {
            mode.SetActive(false);
        }
        gameModes[GameControl.gameMode].SetActive(true);
    }

    /// <summary>
    /// Toggles between game modes
    ///     0 = Survival
    ///     1 = Endless
    /// Main Menu Only
    /// </summary>
    public void ChangeGameMode()
    {
        int currentMode = GameControl.control.getGameMode();
        int nextMode = (currentMode == gameModes.Length - 1) ? 0 : currentMode + 1;

        gameModes[currentMode].SetActive(false);
        gameModes[nextMode].SetActive(true);

        GameControl.control.setGameMode(nextMode);
        EventSystem.current.SetSelectedGameObject(null);
    }

    /// <summary>
    /// Updates current score UI
    /// Game Mode only
    /// </summary>
    public void UpdateCurrentScore()
    {
        int currentScore = ReferenceManager.refManager.scoreManager.GetCurrentScore();
        currentScoreText.text = currentScore.ToString();
    }

    /// <summary>
    /// Updates High Score text UI
    /// Game Mode only
    /// </summary>
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

    /// <summary>
    /// Updates Achievements High Score
    /// Main Menu only
    /// </summary>
    public void UpdateHighScoreMenu()
    {
        survivalHighScore.text = GameControl.highScoreSurvival.ToString();
        endlessHighScore.text = GameControl.highScoreEndless.ToString();
    }
}
