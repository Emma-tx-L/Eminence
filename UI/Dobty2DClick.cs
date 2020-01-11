using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dobty2DClick : MonoBehaviour {

    private Animator dobty2DAnim;

    void Start()
    {
        dobty2DAnim = GetComponent<Animator>();
    }

    public void PlayRandomAnimation()
    {
        if (!dobty2DAnim.GetCurrentAnimatorStateInfo(0).IsTag("Idle")) {
            return;
        }

        int trigger = Random.Range(1, 3);
        string expression;
        
        switch(trigger)
        {
            case 1:
                expression = "DobtyHappy";
                break;
            case 2:
                expression = "DobtyUWU";
                break;
            case 3:
                expression = "DobtyMeh";
                break;
            default:
                expression = "DobtyHappy";
                break;
        }
        dobty2DAnim.SetTrigger(expression);
    }

}
