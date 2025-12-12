using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    public float jumpHeight = 1.8f;
    public float gravity = -18f; // stronger gravity = better game feel

    [Header("Lean Settings")]
    public Transform cameraPivot;
    public float leanAngle = 15f;
    public float leanSpeed = 8f;

    private CharacterController controller;
    private Vector3 velocity;
    private float currentLean = 0f;
    private float targetLean = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // ----- MOVEMENT -----
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(x, 0f, z);
        Vector3 move = transform.TransformDirection(input);
        controller.Move(move * speed * Time.deltaTime);

        // ----- GROUND CHECK + JUMP -----
        if (controller.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f;

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        // ----- GRAVITY -----
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // ----- LEAN -----
        if (Input.GetKey(KeyCode.Q))
            targetLean = leanAngle;
        else if (Input.GetKey(KeyCode.E))
            targetLean = -leanAngle;
        else
            targetLean = 0f;

        currentLean = Mathf.Lerp(currentLean, targetLean, Time.deltaTime * leanSpeed);

        if (cameraPivot != null)
            cameraPivot.localRotation = Quaternion.Euler(0f, 0f, currentLean);
    }
}