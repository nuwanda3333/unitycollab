using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

public class Collectible : MonoBehaviour
{
    [Tooltip("GameEvent scriptable object to trigger the sound in SFXPlayer")]
    public GameEvent soundEvent;

    [Tooltip("estimated 'padded' lifetime of particles, used so GameObject isn't destroyed while particles are alive")]
    public float particlesLifetime = 2f;

    // set to false once effects are being run to prevent multiple effects running from single collectible
    bool isAlive = true;

    // using this to hide the mesh while still leaving the collectible around for the particles to play
    new MeshRenderer renderer;

    ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponentInChildren<MeshRenderer>();
        particles = GetComponentInChildren<ParticleSystem>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isAlive)
        {
            renderer.enabled = false;
            if (particles) particles.Play();
            soundEvent.Raise();
            Destroy(gameObject, particles.main.duration + particlesLifetime);

            // prevent multiple effects being run from one Collectible
            isAlive = false;
        }
    }
}
