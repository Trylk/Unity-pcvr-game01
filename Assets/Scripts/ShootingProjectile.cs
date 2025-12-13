using UnityEngine;
using UnityEngine.InputSystem;

public class VRShooter : MonoBehaviour
{
    public InputActionProperty trigger;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 30f;

    void OnEnable()
    {
        trigger.action.Enable();
    }

    void OnDisable()
    {
        trigger.action.Disable();
    }

    void Update()
    {
        float triggerValue = trigger.action.ReadValue<float>();

        if (triggerValue > 0.8f)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * bulletSpeed;
    }
}
