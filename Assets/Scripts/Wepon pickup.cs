using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public float pickUpRange = 3f; // portée du rayon
    public Transform weaponHolder; // là où l’arme sera tenue
    private Camera playerCam;
    private GameObject currentWeapon;

    void Start()
    {
        playerCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickUpWeapon();
        }
    }

    void TryPickUpWeapon()
    {
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickUpRange))
        {
            if (hit.collider.CompareTag("Weapon"))
            {
                PickUp(hit.collider.gameObject);
            }
        }
    }

    void PickUp(GameObject weapon)
    {
        if (currentWeapon != null)
            DropWeapon();

        currentWeapon = weapon;
        weapon.transform.SetParent(weaponHolder);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        weapon.GetComponent<Rigidbody>().isKinematic = true;
        weapon.GetComponent<Collider>().enabled = false;
    }

    void DropWeapon()
    {
        currentWeapon.transform.SetParent(null);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon.GetComponent<Collider>().enabled = true;
        currentWeapon = null;
    }
}