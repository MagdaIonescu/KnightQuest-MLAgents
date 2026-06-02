using UnityEngine;

public class CollectKeys : MonoBehaviour
{
    public int keysCollected = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            keysCollected++;

            FindObjectOfType<GameUIController>()
                .UpdateKeys(keysCollected);

            Destroy(other.gameObject);
        }
    }
}