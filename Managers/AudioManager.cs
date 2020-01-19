using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [Header("Settings")]
    [SerializeField, Range(0f, 1f)] private float volume = 0.6f;

    [Header("References")]
    [SerializeField] private AudioSource _dobtySoundSource;
    [SerializeField] private AudioClip[] _dobtySounds;
    [SerializeField] private AudioSource _mainThemeSource;
    [SerializeField] private AudioClip[] _themes;

    /// <summary>
    /// Play a happy Dobty sound
    /// </summary>
    /// <param name="ignoreControl">If true, play sound regardless of sound settings</param>
    public void PlayHappy(bool ignoreControl)
    {
        if (GameControl.dobtyGameSounds || ignoreControl)
        {
            _dobtySoundSource.PlayOneShot(_dobtySounds[0], volume);
        }
    }

    /// <summary>
    /// Play an undecisive Dobty sound
    /// </summary>
    /// <param name="ignoreControl">If true, play sound regardless of sound settings</param>
    public void PlayMeh(bool ignoreControl)
    {
        if (GameControl.dobtyGameSounds || ignoreControl)
        {
            _dobtySoundSource.PlayOneShot(_dobtySounds[1], volume);
        }
    }

    /// <summary>
    /// Play a sad Dobty sound
    /// </summary>
    /// <param name="ignoreControl">If true, play sound regardless of sound settings</param>
    public void PlaySad(bool ignoreControl)
    {
        if (GameControl.dobtyGameSounds || ignoreControl)
        {
            _dobtySoundSource.PlayOneShot(_dobtySounds[2], volume);
        }
    }

    /// <summary>
    /// Plays Game Over rift and switches to quiet theme once rift is complete
    /// </summary>
    public IEnumerator PlayGameOver()
    {
        _dobtySoundSource.PlayOneShot(_dobtySounds[3], volume);
        _mainThemeSource.Stop();
        yield return new WaitForSeconds(_dobtySoundSource.clip.length);
        _mainThemeSource.PlayOneShot(_themes[1]);

    }
}
