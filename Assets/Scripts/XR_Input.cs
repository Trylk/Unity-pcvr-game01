using UnityEngine;
using UnityEngine.InputSystem;

public class XRI_Hand_Input : MonoBehaviour
{
    public enum HandSide
    {
        Left,
        Right
    }

    [Header("Hand Selection")]
    public HandSide hand = HandSide.Right;

    [Header("Input Actions")]
    public InputActionProperty trigger;
    public InputActionProperty grip;
    public InputActionProperty joystick;
    public InputActionProperty primaryButton;

    void OnEnable()
    {
        trigger.action.Enable();
        grip.action.Enable();
        joystick.action.Enable();
        primaryButton.action.Enable();
    }

    void OnDisable()
    {
        trigger.action.Disable();
        grip.action.Disable();
        joystick.action.Disable();
        primaryButton.action.Disable();
    }

    void Update()
    {
        float triggerValue = trigger.action.ReadValue<float>();
        float gripValue = grip.action.ReadValue<float>();
        Vector2 joyValue = joystick.action.ReadValue<Vector2>();
        bool primaryPressed = primaryButton.action.IsPressed();

        string side = hand == HandSide.Left ? "Left" : "Right";

        // Debug
        if (triggerValue > 0.1f)
            Debug.Log($"{side} Trigger: {triggerValue}");

        if (gripValue > 0.1f)
            Debug.Log($"{side} Grip: {gripValue}");

        if (joyValue != Vector2.zero)
            Debug.Log($"{side} Joystick: {joyValue}");

        if (primaryPressed)
            Debug.Log($"{side} Primary Button Pressed");
    }
}
