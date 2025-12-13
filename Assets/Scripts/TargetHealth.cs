using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    Renderer rend;
    Color originalColor;

    void Awake()
    {
        currentHealth = maxHealth;

        rend = GetComponent<Renderer>();
        if (rend != null)
            originalColor = rend.material.color;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. HP = {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        currentHealth = 0;

        if (rend != null)
            rend.material.color = Color.red;

        Debug.Log($"{gameObject.name} is DEAD");
    }
}
