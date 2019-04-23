using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadStartMenu()
    {
        StartCoroutine(LoadStart());
    }

    IEnumerator LoadStart()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Start Screen");
    }
}
