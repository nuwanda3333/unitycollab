using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCanvas : MonoBehaviour
{
    public float waitTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KillObject());
    }

   IEnumerator KillObject()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
