using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualGameFlow : MonoBehaviour
{
    public int totalKeys = 3;

    private CollectKeys collectKeys;
    private DynamicLoading loader;
    private int lastKeyCount = 0;

    void Start()
    {
        collectKeys = GetComponent<CollectKeys>();
        loader = FindObjectOfType<DynamicLoading>();

        lastKeyCount = collectKeys.keysCollected;
    }

    void Update()
    {
        // Gestionare chei
        if (collectKeys.keysCollected > lastKeyCount)
        {
            lastKeyCount = collectKeys.keysCollected;

            if (collectKeys.keysCollected < totalKeys)
            {
                loader.InstantiereObiect();
            }
            else
            {
                GameUIController ui = FindObjectOfType<GameUIController>();

                if (ui != null)
                    ui.ShowMessage("Enemy!");

                EnemyManager manager = FindObjectOfType<EnemyManager>();

                if (manager != null)
                    manager.ActiveazaUrmatorulInamic();
            }
        }

        // Verificare victorie
        GameUIController gameUI = FindObjectOfType<GameUIController>();

        if (gameUI != null)
        {
            if (gameUI.GetEnemiesLeft() >= 3)
            {
                SceneManager.LoadScene("LastScene");
            }
        }
    }
}