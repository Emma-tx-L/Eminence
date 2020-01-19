using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxTheme : MonoBehaviour {
    
    [Header("References")]
    [SerializeField] private Material lightTheme;
    [SerializeField] private Material darkTheme;

	private void Awake () {
        UpdateColourTheme();
	}
	
    /// <summary>
    /// Updates the skybox based on user settings
    /// </summary>
	public void UpdateColourTheme()
    {
        if (GameControl.control.getThemePreference())
        {
            RenderSettings.skybox = lightTheme;
        }
        else
        {
            RenderSettings.skybox = darkTheme;
        }
    }
}
