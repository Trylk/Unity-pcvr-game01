using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletDamage : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed = 50f;
    public float damage = 6f;
    public float lifeTime = 15f;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // Launch the bullet forward
        rb.linearVelocity = transform.forward * speed;

        // Auto-destroy after time
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
