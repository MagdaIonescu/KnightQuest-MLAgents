using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartAI()
    {
        SceneManager.LoadScene("MySceneAI");
    }

    public void StartManual()
    {
        SceneManager.LoadScene("MySceneManually");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
