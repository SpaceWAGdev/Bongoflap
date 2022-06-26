using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public static void LoadMainGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public static void LoadSettings()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
