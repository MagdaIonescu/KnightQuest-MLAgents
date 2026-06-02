using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 20f;
    public EnemyManager managerInamici;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Moare();
        }
    }

    void Moare()
    {
        gameObject.SetActive(false);

        if (managerInamici != null)
        {
            managerInamici.InamicEliminat();
        }
    }
}