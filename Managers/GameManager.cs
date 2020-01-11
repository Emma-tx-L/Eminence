using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

	// Use this for initialization
	void Awake () {
		if (gameManager == null)
        {
            gameManager = this;
        } else if (gameManager != this)
        {
            Destroy(gameObject);
        }
	}
	

    public void EndGame()
    {
        ReferenceManager.refManager.timeManager.EndGame();
        GameObject gameOverCanvas = ReferenceManager.refManager.gameOverCanvas;
        gameOverCanvas.SetActive(true);
        Animator gameOverCanvasAnim = gameOverCanvas.GetComponent<Animator>();
        gameOverCanvasAnim.SetTrigger("GameOver");
    }
}
