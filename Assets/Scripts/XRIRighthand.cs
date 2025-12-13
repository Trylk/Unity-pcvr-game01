using UnityEngine;
using UnityEngine.InputSystem;

public class XRI_RightHand_Input : MonoBehaviour
{
    [Header("Input Actions (XRI RightHand)")]
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

        // Debug (visible dans la Console)
        if (triggerValue > 0.1f)
            Debug.Log("Right Trigger : " + triggerValue);

        if (gripValue > 0.1f)
            Debug.Log("Right Grip : " + gripValue);

        if (joyValue != Vector2.zero)
            Debug.Log("Right Joystick : " + joyValue);

        if (primaryPressed)
            Debug.Log("Right Primary Button Pressed");
    }
}
