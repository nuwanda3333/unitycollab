using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string nextScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadNextSceneAsync());
        }
    }

    IEnumerator LoadNextSceneAsync()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(nextScene);
        while (!loading.isDone)
        {
            Debug.Log("Loading");
            yield return null;
        }
    }

}
