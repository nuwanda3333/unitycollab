/**
 * Last second hack to allow for exit with Esc key pressed!
 * 
 * Random quote: "Adriaaaaan!!!" - Rocky Balboa
 */


using UnityEngine;

public class EscToExit : MonoBehaviour
{
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) Application.Quit();
    }
}
