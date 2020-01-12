using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReferenceManager : MonoBehaviour {

    public static ReferenceManager refManager = null;

    //Dobty
    public GameObject Dobty;
    public DobtyHP dobtyHP;
    public Animator DobtyIconAnim;

    //Other Managers
    public ScoreManager scoreManager;
    public TimeManager timeManager;
    public SkyboxTheme theme;
    public LoadSceneManager loadSceneManager;
    
    //UI Elements
    public Slider HPSlider;
    public GameObject HPSliderObject;
    public GameObject gameOverCanvas;

	void Awake () {
		if (refManager == null)
        {
            refManager = this;
        } 
        else if (refManager != this)
        {
            Destroy(gameObject);
        }
	}
}
