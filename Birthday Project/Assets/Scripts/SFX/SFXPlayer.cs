/**
 * SFXPlayer.cs - manages an array of AudioClips and plays them in sequence or picks a random one
 * 
 * To play the sounds we use a pool of AudioSources which we just grab from the current GameObject.
 * So to make the AudioSource pool greater add more AudioSources to the GameObject.
 * 
 * Usage:
 * - Call PlayNext() to play the next sound in the sequence, looping after reaching the end of the 
 * AudioClip array
 * 
 * - Call PlayRandom() to play a random sound in the array without interfering with PlayNext's sequence
 * 
 * 
 * Random quote: "I'm a cold heart-breaker, fit to burn, and I'll rip your heart in two" - Guns'n'Roses
 */


using System;
using UnityEngine;


// so that we have at least one AudioSource in the GameObject
[RequireComponent(typeof(AudioSource))]
public class SFXPlayer : MonoBehaviour
{
    // sounds entered from editor
    public AudioClip[] clips;

    //  AudioSources through which we play the clips - avoids the need for each clip to come with its own AudioSource
    AudioSource[] pool;

    // keeps track of where we are in clips array
    int clipIndex = 0;

    // keeps track of where we are in audioSrcPool;
    int poolIndex = 0;


    private void Start()
    {
        // grab local AudioSource to use them as a pool
        pool = GetComponents<AudioSource>();
    }


    /**
     * Play the next sound and increment index - called by EventListener
     */
    public void PlayNext()
    {
        // throw error if we forgot to fill array in editor, hopefully we'll hit at least one pickup before deploying :)
        if (clips.Length == 0) throw new IndexOutOfRangeException("Empty clips array in SFXPlayer!");

        // prepare and play AudioSource in the pool and increment index;
        pool[poolIndex].Stop();
        pool[poolIndex].clip = clips[clipIndex];
        pool[poolIndex].Play();

        // increment with wrap-around
        clipIndex = (clipIndex + 1) % clips.Length;
        poolIndex = (poolIndex + 1) % pool.Length;

    }

    
    public void PlayRandom()
    {
        // throw error if we forgot to fill array in editor, hopefully we'll hit at least one pickup before deploying :)
        if (clips.Length == 0) throw new IndexOutOfRangeException("Empty clips array in SFXPlayer!");

        // pick a clip, any clip
        int n = UnityEngine.Random.Range(0, clips.Length);

        // prepare and play AudioSource in the pool and increment index;
        pool[poolIndex].Stop();
        pool[poolIndex].clip = clips[n];
        pool[poolIndex].Play();

        // increment with wrap-around
        poolIndex = (poolIndex + 1) % pool.Length;
    }
}
