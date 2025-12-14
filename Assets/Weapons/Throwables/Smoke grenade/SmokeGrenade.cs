using UnityEngine;
using System.Collections;

public class SmokeGrenade : MonoBehaviour
{
    [Header("Timing")]
    [SerializeField] private float fuseTime = 2.5f;
    [SerializeField] private float smokeDuration = 15f;

    [Header("Smoke")]
    [SerializeField] private GameObject smokePrefab;
    [SerializeField] private Transform smokeSpawnPoint;

    [Header("Physics")]
    [SerializeField] private Rigidbody rb;

    bool ignited = false;

    void Awake()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        StartCoroutine(FuseRoutine());
    }

    IEnumerator FuseRoutine()
    {
        yield return new WaitForSeconds(fuseTime);
        Ignite();
    }

    void Ignite()
    {
        if (ignited) return;
        ignited = true;

        // Stop rolling like a real grenade
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;

        // Spawn smoke
        GameObject smoke = Instantiate(
            smokePrefab,
            smokeSpawnPoint ? smokeSpawnPoint.position : transform.position,
            Quaternion.identity
        );

        smoke.transform.SetParent(null);

        StartCoroutine(EndSmoke(smoke));
    }

    IEnumerator EndSmoke(GameObject smoke)
    {
        yield return new WaitForSeconds(smokeDuration);

        if (smoke)
            Destroy(smoke);

        // Hide grenade shell
        gameObject.SetActive(false);
    }
}
