using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoBallRotator : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject ballLight;
    public GameObject ballLight2;
    public Gradient colorGradient;
    public Gradient colorGradient2;
    Light light1;
    Light light2;
    // Start is called before the first frame update
    void Start()
    {
        light1 = ballLight.GetComponent<Light>();
        light2 = ballLight2.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.up * rotationSpeed * Time.deltaTime);
        ballLight2.transform.Rotate(ballLight2.transform.up * -rotationSpeed * 2 * Time.deltaTime);

    }

    public void StartRotating()
    {
        rotationSpeed = 45f;
        ballLight.SetActive(true);
        ballLight2.SetActive(true);
        StartCoroutine(colorChanger());
    }

    IEnumerator colorChanger()
    {
        while(true)
        {
            light1.color = colorGradient.Evaluate(Random.Range(0f, 1f));
            yield return new WaitForSeconds(Random.Range(1f, 4f));
            light2.color = colorGradient2.Evaluate(Random.Range(0f, 1f));
            yield return new WaitForSeconds(Random.Range(1f, 4f));
        }
 
    }
}
