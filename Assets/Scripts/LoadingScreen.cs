using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HandleLoadStart());
    }

    IEnumerator HandleLoadStart()
    {
        yield return new WaitForSeconds(3);
        FindObjectOfType<LevelLoader>().LoadStartMenu();
    }
}
