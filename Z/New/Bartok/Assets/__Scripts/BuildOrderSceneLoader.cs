
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildOrderSceneLoader : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    {
        int currentActiveScene = SceneManager.GetActiveScene().buildIndex;
        if (currentActiveScene + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentActiveScene + 1);
        }
        else
        {
            throw new Exception("LoadNextScene called from End Scene!");
        }
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
