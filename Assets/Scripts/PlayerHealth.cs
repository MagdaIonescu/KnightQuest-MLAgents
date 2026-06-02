using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    private bool isDead = false;
    public GameObject deathEffectCanvas;

    public void TakeDamage(float damage)
    {
        if (isDead)
        {
            return;
        }
        health -= damage;
        FindObjectOfType<GameUIController>().UpdateHealth(health);
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }
    void Die()
    {
        isDead = true;
        deathEffectCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
