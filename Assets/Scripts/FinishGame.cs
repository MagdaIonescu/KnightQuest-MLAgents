using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    public GameObject finishCanvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartGame();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            QuitGame();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MyScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            finishCanvas.SetActive(true); 
    }
}
