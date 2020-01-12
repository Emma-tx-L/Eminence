using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxTheme : MonoBehaviour {
    public Material lightTheme;
    public Material darkTheme;

	private void Awake () {
        UpdateColourTheme();
	}
	
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
