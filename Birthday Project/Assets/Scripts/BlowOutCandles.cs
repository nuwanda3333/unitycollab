using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

public class BlowOutCandles : MonoBehaviour
{
    public AudioSource blowingCandles;
    public GameEvent candleBlown;

    static int blown;

    private void Update()
    {

    }

    public void OnMouseDown()
    {
         if (gameObject.activeInHierarchy == true)
         {
            ++blown;
            if (blown >= 4)
            {
                Debug.Log("RAISE");
                candleBlown.Raise();
            }
            gameObject.SetActive(false);
            blowingCandles.Play();

            Debug.Log("Blown: " + blown);

        }
             

    }
}
