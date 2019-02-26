using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowOutCandles : MonoBehaviour
{
    public AudioSource blowingCandles;
    

        public void OnMouseDown()
        {
             if (gameObject.activeInHierarchy == true)
                 {
                     gameObject.SetActive(false);
                     blowingCandles.Play();
                }
             

    }



    




}
