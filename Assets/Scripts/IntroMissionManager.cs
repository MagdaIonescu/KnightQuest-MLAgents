using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMissionManager : MonoBehaviour
{
    public GameObject canvasIntro; 
    public GameObject canvasGameplay; 
    void Start()
    {
        canvasIntro.SetActive(true); 
        canvasGameplay.SetActive(false); 
        Time.timeScale = 0; 
    }
    public void AcceptMission()
    {
        canvasIntro.SetActive(false); 
        canvasGameplay.SetActive(true);
        Time.timeScale = 1; 
    }
    public void DeclineMission()
    {
        Application.Quit(); 
    }
}

