using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Replacer : MonoBehaviour
{
    public GameObject prefab;
    //public Transform newParent;
    // Start is called before the first frame update
    bool done = false;
    void Awake()
    {
        Debug.Log("START");
        ReplaceWalls();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("THIS?");
        if (!done) ReplaceWalls();
    }

    void ReplaceWalls()
    {
        Transform[] originals = transform.GetComponentsInChildren<Transform>();

        for (int i = 1; i < originals.Length; ++i)
        {
            // GameObject temp = Instantiate(prefab, originals[i].position, originals[i].rotation);
            GameObject temp = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
            temp.transform.position = originals[i].position;
            temp.transform.rotation = originals[i].rotation;
            temp.transform.localScale = originals[i].localScale;
        }
        done = true;
    }
}
