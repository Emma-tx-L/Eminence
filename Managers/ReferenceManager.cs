using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReferenceManager : MonoBehaviour {

    public static ReferenceManager refManager = null;

    //Dobty
    public GameObject Dobty;
    public DobtyHP dobtyHP;

    //Other Managers
    public ScoreManager scoreManager;
    public TimeManager timeManager;
    
    //UI Elements
    public Slider HPSlider;
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
