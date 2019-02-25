using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSounds : MonoBehaviour
{
    AudioSource[] audioSources;
   // int index;

    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        StartCoroutine(playSounds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator playSounds()
    {
        while (true)
        {
            audioSources[0].pitch = Random.Range(.5f, 1.1f);

            yield return new WaitForSeconds(Random.Range(1f, 5f));
            audioSources[1].pitch = Random.Range(-1.1f, 1.1f);
            yield return new WaitForSeconds(Random.Range(1f, 5f));

        }
    }
}
