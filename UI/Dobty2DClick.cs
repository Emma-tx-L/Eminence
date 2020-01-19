using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dobty2DClick : MonoBehaviour {

    private Animator _dobty2DAnim;
    private AudioManager audioManager;

    private void Awake()
    {
        _dobty2DAnim = GetComponent<Animator>();
        audioManager = ReferenceManager.refManager.audioManager;
    }

    /// <summary>
    /// Makes 2D Dobty Sprite play a random expression animation
    /// </summary>
    public void PlayRandomAnimation()
    {
        if (!_dobty2DAnim.GetCurrentAnimatorStateInfo(0).IsTag("Idle")) {
            return;
        }

        int trigger = Random.Range(1, 3);
        string expression;

        switch(trigger)
        {
            case 1:
                expression = "DobtyHappy";
                audioManager.PlayHappy(true);
                break;
            case 2:
                expression = "DobtyUWU";
                audioManager.PlayMeh(true);
                break;
            case 3:
                expression = "DobtyMeh";
                audioManager.PlayMeh(true);
                break;
            default:
                expression = "DobtyHappy";
                audioManager.PlayHappy(true);
                break;
        }
        _dobty2DAnim.SetTrigger(expression);
    }

}
