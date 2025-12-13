using UnityEngine;

public class DesktopShooter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private Transform firePoint;

    [Header("Fire Settings")]
    [SerializeField] private float fireRate = 0.15f;

    [Header("Bullet Settings")]
    [SerializeField] private float bulletSpeed = 60f; // 👈 CONFIGURABLE SPEED

    float nextFireTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPool == null)
        {
            Debug.LogError("DesktopShooter: BulletPool not assigned!");
            return;
        }

        if (firePoint == null)
        {
            Debug.LogError("DesktopShooter: FirePoint not assigned!");
            return;
        }

        GameObject bullet = bulletPool.GetBullet(
            firePoint.position,
            firePoint.rotation
        );

        if (bullet == null)
        {
            Debug.LogWarning("DesktopShooter: Bullet pool exhausted!");
            return;
        }

        // 🔥 THIS is the important part
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("DesktopShooter: Bullet has no Rigidbody!");
        }
    }
}
