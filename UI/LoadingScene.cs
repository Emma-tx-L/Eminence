using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour {

    [SerializeField]
    private Image _progressBar;

	private void Start () {
        StartCoroutine(LoadGameScene());
	}
	
	private IEnumerator LoadGameScene()
    {
        AsyncOperation level = SceneManager.LoadSceneAsync("GameMode");

        while (level.progress < 1)
        {
            _progressBar.fillAmount = level.progress;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();
    }
}
