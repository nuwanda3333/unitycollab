using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoBallRotator : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject ballLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.up * rotationSpeed * Time.deltaTime);
    }

    public void StartRotating()
    {
        rotationSpeed = 45f;
        ballLight.SetActive(true);
    }
}
