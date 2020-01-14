using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField]
    private float volume = 0.6f;

    [SerializeField]
    private AudioSource _dobtySoundSource;

    [SerializeField]
    private AudioClip[] _dobtySounds;

    [SerializeField]
    private AudioSource _mainThemeSource;

    [SerializeField]
    private AudioClip[] _themes;

	public void PlayHappy(bool ignoreControl)
    {
        if (GameControl.dobtyGameSounds || ignoreControl)
        {
            _dobtySoundSource.PlayOneShot(_dobtySounds[0], volume);
        }
    }

    public void PlayMeh(bool ignoreControl)
    {
        if (GameControl.dobtyGameSounds || ignoreControl)
        {
            _dobtySoundSource.PlayOneShot(_dobtySounds[1], volume);
        }
    }

    public void PlaySad(bool ignoreControl)
    {
        if (GameControl.dobtyGameSounds || ignoreControl)
        {
            _dobtySoundSource.PlayOneShot(_dobtySounds[2], volume);
        }
    }

    public IEnumerator PlayGameOver()
    {
        _dobtySoundSource.PlayOneShot(_dobtySounds[3], volume);
        _mainThemeSource.Stop();
        yield return new WaitForSeconds(_dobtySoundSource.clip.length);
        _mainThemeSource.PlayOneShot(_themes[1]);

    }
}
