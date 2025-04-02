using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Utility : MonoBehaviour
{
    /// <summary>
    /// Switch Scenes
    /// </summary>
    /// <param name="sceneName"></param>
    public static void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Error: SceneName is Null or Empty");
        }
    }

    /// <summary>
    /// Quit/Exit GameMode
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
        EditorApplication.ExitPlaymode();
    }
}

