using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoopManager1 : MonoBehaviour
{
    public string nextSceneName = "Scene2"; // Specify the next scene to load
    public GameObject hintKey;

    private bool isTransitioning = false;

    private void OnTriggerEnter(Collider other)
    {
            SceneManager.LoadScene(nextSceneName);

    }

    private IEnumerator LoadNextSceneAsync()
    {
        // Load the next scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextSceneName);

        // Wait until the next scene is fully loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Reset the flag after the scene is loaded
        isTransitioning = false;
        hintKey.SetActive(false);
    }
}
