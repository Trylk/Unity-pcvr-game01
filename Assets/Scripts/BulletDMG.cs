using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damage = 5f;
    public float destroyDelay = 0.02f;

    void OnCollisionEnter(Collision collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }

        // Destroy bullet after hit
        Destroy(gameObject, destroyDelay);
    }
}
