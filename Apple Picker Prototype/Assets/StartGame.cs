using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene ("_Scene_0");
    }
}