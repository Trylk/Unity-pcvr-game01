using UnityEngine;
using UnityEngine.InputSystem;

public class XRI_LeftHand_Input : MonoBehaviour
{
    [Header("Input Actions (XRI LeftHand)")]
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

        // Debug Console
        if (triggerValue > 0.1f)
            Debug.Log("Left Trigger: " + triggerValue);

        if (gripValue > 0.1f)
            Debug.Log("Left Grip: " + gripValue);

        if (joyValue != Vector2.zero)
            Debug.Log("Left Joystick: " + joyValue);

        if (primaryPressed)
            Debug.Log("Left Primary Button Pressed");
    }
}
