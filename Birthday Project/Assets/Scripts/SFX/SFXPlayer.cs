using System;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SFXPlayer : MonoBehaviour
{
    // sounds entered from editor
    public AudioClip[] clips;

    AudioSource[] audioSrcPool;

    // keeps track of where we are in clips array
    int index = 0;

    // keeps track of where we are in audioSrcPool;
    int poolIndex = 0;


    private void Start()
    {
        // grab local AudioSource to use them as a pool
        audioSrcPool = GetComponents<AudioSource>();
    }


    /**
     * Play the next sound and increment index - called by EventListener
     */
    public void PlayNext()
    {
        // throw error if we forgot to fill array in editor, hopefully we'll hit at least one pickup before deploying :)
        if (clips.Length == 0) throw new IndexOutOfRangeException("Empty clips array in SFXPlayer!");

        // prepare and play AudioSource in the pool and increment index;
        audioSrcPool[poolIndex].Stop();
        audioSrcPool[poolIndex].clip = clips[index++];
        audioSrcPool[poolIndex].Play();
        ++poolIndex;

        // revert to 0 if arrays exhausted
        if (index >= clips.Length) index = 0;
        if (poolIndex >= audioSrcPool.Length) poolIndex = 0;
    }
}
