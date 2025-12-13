using UnityEngine;
using UnityEngine.InputSystem;

public class VRLocomotion : MonoBehaviour
{
    [Header("References")]
    public Transform xrOrigin;     // XR Origin (VR)
    public Transform head;         // Main Camera (HMD)

    [Header("Input")]
    public InputActionProperty moveAction; // Left joystick

    [Header("Movement")]
    public float moveSpeed = 2f;

    void OnEnable()
    {
        moveAction.action.Enable();
    }

    void OnDisable()
    {
        moveAction.action.Disable();
    }

    void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        if (input == Vector2.zero) return;

        // Get head forward direction (ignore vertical tilt)
        Vector3 forward = head.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = head.right;
        right.y = 0;
        right.Normalize();

        Vector3 moveDir = forward * input.y + right * input.x;

        xrOrigin.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
