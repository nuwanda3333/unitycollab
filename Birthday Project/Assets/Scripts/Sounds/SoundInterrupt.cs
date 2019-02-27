/**
 * Quick last minute hack to fade out the song for quietFor seconds, then restore level to previous volume
 */

using System.Collections;
using UnityEngine;

public class SoundInterrupt : MonoBehaviour
{
    public float quietFor = 3f;
    public float level = 0.1f;
    public float transitionTime = 0.2f;

    new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();    
    }


    /**
     * Run this function from an event listener, it fades out the sound gradually, then restores it after quietFor seconds
     */
    public void TemporaryFade()
    {
        StartCoroutine(MuteForCoroutine());
    }

    IEnumerator MuteForCoroutine()
    {
        float startLevel = audio.volume;

        StartCoroutine(VolumeTransitionCoroutine(level, transitionTime));
        yield return new WaitForSeconds(quietFor);
        StartCoroutine(VolumeTransitionCoroutine(startLevel, transitionTime));
    }


    /**
     * grabbed from https://github.com/irenenaya/Breakout_Unity/blob/master/Breakout_Unity/Assets/Scripts/AudioClipControls.cs
     */
    IEnumerator VolumeTransitionCoroutine(float target, float duration)
    {
        float from = audio.volume;
        float invDuration = 1.0f / duration;

        // the "counter" variable to track position within Lerp
        float progress = Time.unscaledDeltaTime * invDuration;

        while (Mathf.Abs(audio.volume - target) > 0.0f)
        {
            audio.volume = Mathf.Lerp(from, target, progress);
            progress += Time.unscaledDeltaTime * invDuration;
            yield return null;
        }
    }
}
