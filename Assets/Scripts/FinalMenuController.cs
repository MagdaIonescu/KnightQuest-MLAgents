using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMenuController : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("IntroScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
