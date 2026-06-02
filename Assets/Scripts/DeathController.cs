using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu"; 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            GoToMainMenu();
        if (Input.GetKeyDown(KeyCode.N))
            QuitGame();
    }
    void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName); 
    }
    void QuitGame()
    {
        Application.Quit(); 
    }
}
