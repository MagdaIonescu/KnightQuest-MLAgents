using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public int requiredKeys = 3;
    public int requiredEnemiesDefeated = 1;

    public AudioSource openDoorAudio;
    public AudioSource closeDoorAudio;

    public string nextSceneName = "NextScene";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectKeys playerKeys = other.GetComponent<CollectKeys>();
            GameUIController gameUIController =
                FindObjectOfType<GameUIController>();

            if (playerKeys != null &&
                playerKeys.keysCollected >= requiredKeys &&
                gameUIController != null &&
                gameUIController.GetEnemiesLeft() >= requiredEnemiesDefeated)
            {
                openDoorAudio.Play();

                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                closeDoorAudio.Play();

                if (gameUIController != null)
                {
                    if (playerKeys.keysCollected < requiredKeys)
                        gameUIController.ShowMessage("Need more keys!");

                    else if (gameUIController.GetEnemiesLeft() < requiredEnemiesDefeated)
                        gameUIController.ShowMessage("Defeat the enemy first!");
                }
            }
        }
    }
}