/**
 * Collectibles.cs - a collectible script that fires off a sound event and runs particles upon collision
 * 
 * NOTES: We disable the renderer so that we can leave the game object around while the particles are running
 * We use particlesLifeTime to give the particles some time after trigger has been entered.
 * A bool isAlive is used to signify the collectible can be collected, i.e. the effects will be run.
 * After trigger has been entered we flip isAlive to false, thus preventing the effects from being run again 
 * if the trigger were to be entered again after the initial "collision"
 * 
 * Random quote: "Zed's dead, baby, Zed's dead." - Bruce Willis in Pulp Fiction 
 */

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
