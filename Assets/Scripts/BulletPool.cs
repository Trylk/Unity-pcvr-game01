using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolSize = 30;

    List<GameObject> pool = new List<GameObject>();

    void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject b = Instantiate(bulletPrefab);
            b.SetActive(false);
            pool.Add(b);
        }
    }

    public GameObject GetBullet(Vector3 pos, Quaternion rot)
    {
        foreach (GameObject b in pool)
        {
            if (!b.activeInHierarchy)
            {
                b.transform.SetPositionAndRotation(pos, rot);
                b.SetActive(true);
                return b;
            }
        }

        return null; // pool exhausted
    }
}
