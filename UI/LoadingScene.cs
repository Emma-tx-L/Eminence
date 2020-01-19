using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour {
    
    [Header("References")]
    [SerializeField] private Image _progressBar;

	private void Start () {
        StartCoroutine(LoadGameScene());
	}
	
    /// <summary>
    /// Loads Game Mode and reports progress in loading bar UI
    /// </summary>
    /// <returns></returns>
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
