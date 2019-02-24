using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

public class Collectible : MonoBehaviour
{
    public ParticleSystem particles;
    public float particlesDuration = 1f;

    public GameEvent soundEvent;

    bool isAlive = true;

    // using this to hide the mesh while still leaving the collectible around for the particles to play
    new MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponentInChildren<MeshRenderer>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isAlive)
        {
            renderer.enabled = false;
            // if (particles) particles.Play();
            soundEvent.Raise();
            Destroy(gameObject, particlesDuration);

            // prevent multiple effects being run from one Collectible
            isAlive = false;
        }
    }
}
