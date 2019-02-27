using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

public class Table : MonoBehaviour
{
    public GameEvent tableApproached;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(other.name);
            tableApproached.Raise();
        }
    }
}
