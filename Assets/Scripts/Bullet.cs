using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class BulletDamage : MonoBehaviour
{
    [Header("Stats")]
    public float damage = 25f;
    public float lifeTime = 15f;

    Rigidbody rb;
    float deathTime;
    bool initialized;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // Physics setup (do NOT fight gravity)
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void OnEnable()
    {
        // Lifetime always respected
        deathTime = Time.time + lifeTime;
        initialized = true;
    }

    void Update()
    {
        if (!initialized) return;

        if (Time.time >= deathTime)
        {
            Disable();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Ignore triggers just in case
        if (collision.collider.isTrigger) return;

        // Damage if possible
        Health health = collision.collider.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        Disable();
    }

    void Disable()
    {
        initialized = false;
        rb.linearVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
