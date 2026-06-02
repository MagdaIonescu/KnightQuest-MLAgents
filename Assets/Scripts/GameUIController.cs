using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public TextMeshProUGUI messageText;
    private int collectedKeys = 0;
    private int totalKeys = 3;
    private float playerHealth = 100f;
    private int enemiesDefeated = 0;
    private int totalEnemies = 3;

    public void UpdateKeys(int currentKeys)
    {
        collectedKeys = currentKeys;
        UpdateUIText();
    }

    public void UpdateHealth(float currentHealth)
    {
        playerHealth = currentHealth;
        UpdateUIText();
    }

    public void UpdateEnemies(int defeatedEnemies, int totalEnemyCount)
    {
        enemiesDefeated = defeatedEnemies;
        totalEnemies = totalEnemyCount;
        UpdateUIText();
    }

    private void UpdateUIText()
    {
        uiText.text = "Keys: " + collectedKeys + "/" + totalKeys + "\n" +
                      "Life: " + playerHealth + "%\n" +
                      "Enemies: " + enemiesDefeated + "/" + totalEnemies;
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        StartCoroutine(HideMessage());
    }

    private IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(3f);
        messageText.text = "";
    }
    public int GetEnemiesLeft()
    {
        return enemiesDefeated; 
    }

}
