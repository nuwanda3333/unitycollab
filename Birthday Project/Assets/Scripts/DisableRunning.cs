/**
 * A massive last-minute hack to disable running on the ThirdPersonUserControl
 * 
 * Random quote: "You're far to keen on where and how, but not so hot on why" - Ted Nealey - Jesus Christ Superstar
 */

using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class DisableRunning : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // We're really running out of time! Don't judge! :P
            var user = other?.GetComponent<ThirdPersonUserControl>();
            if (user) user.dontRun = true;
        }
    }
}
