using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    public float jumpHeight = 1.8f;
    public float gravity = -9.81f;

    [Header("Lean Settings")]
    public Transform cameraPivot;      // Camera or camera holder
    public float leanAngle = 15f;       // How far it leans
    public float leanSpeed = 8f;        // How fast it leans

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
        // ----- MOVEMENT INPUT -----
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(x, 0f, z);
        Vector3 move = transform.TransformDirection(input);

        controller.Move(move * speed * Time.deltaTime);

        // ----- GROUND CHECK -----
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // ----- JUMP -----
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // ----- GRAVITY -----
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // ----- LEAN INPUT -----
        if (Input.GetKey(KeyCode.Q))
            targetLean = leanAngle;
        else if (Input.GetKey(KeyCode.E))
            targetLean = -leanAngle;
        else
            targetLean = 0f;

        // Smooth lean
        currentLean = Mathf.Lerp(currentLean, targetLean, Time.deltaTime * leanSpeed);

        if (cameraPivot != null)
        {
            cameraPivot.localRotation = Quaternion.Euler(0f, 0f, currentLean);
        }
    }
}
