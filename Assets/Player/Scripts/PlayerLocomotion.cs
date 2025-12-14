using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerLocomotion_CharacterController : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 3.5f;
    public float sprintSpeed = 6f;
    public float gravity = -9.81f;
    public float jumpForce = 1.5f;

    [Header("Mouse Look")]
    public Transform cameraTransform;
    public float mouseSensitivity = 2f;
    public float maxLookX = 85f;

    [Header("Lean")]
    public float leanOffset = 0.1f;
    public float leanSpeed = 8f;

    private CharacterController controller;
    private Vector3 velocity;
    private float rotationX;
    private Vector3 cameraDefaultLocalPos;
    private float targetLean;

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        if (cameraTransform == null)
        {
            Debug.LogError("CameraTransform not assigned.");
            enabled = false;
            return;
        }

        cameraDefaultLocalPos = cameraTransform.localPosition;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
        HandleLean();
        HandleMovement();
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool sprinting = Input.GetKey(KeyCode.LeftShift);
        float speed = sprinting ? sprintSpeed : walkSpeed;

        Vector3 move = transform.right * x + transform.forward * z;
        move *= speed;

        if (controller.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f;

            if (Input.GetKeyDown(KeyCode.Space))
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 finalMove = move + velocity;
        controller.Move(finalMove * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -maxLookX, maxLookX);
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }

    void HandleLean()
    {
        if (Input.GetKey(KeyCode.Q))
            targetLean = -leanOffset;
        else if (Input.GetKey(KeyCode.E))
            targetLean = leanOffset;
        else
            targetLean = 0f;

        Vector3 targetPos = cameraDefaultLocalPos + Vector3.right * targetLean;
        cameraTransform.localPosition =
            Vector3.Lerp(cameraTransform.localPosition, targetPos, leanSpeed * Time.deltaTime);
    }
}
