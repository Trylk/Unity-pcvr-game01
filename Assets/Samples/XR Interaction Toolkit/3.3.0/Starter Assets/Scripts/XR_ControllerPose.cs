using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class XR_ControllerPose : MonoBehaviour
{
    public enum HandSide
    {
        Left,
        Right
    }

    [Header("Hand")]
    [SerializeField] private HandSide hand = HandSide.Right;

    [Header("Tracked Model")]
    [SerializeField] private Transform controllerModel;

    private XRController xrController;

    void OnEnable()
    {
        // Cherche le contrôleur XR correspondant
        xrController = hand == HandSide.Left 
            ? XRController.leftHand 
            : XRController.rightHand;
    }

    void Update()
    {
        if (xrController == null) return;

        // Position
        Vector3 position = xrController.devicePosition.ReadValue();
        transform.localPosition = position;

        // Rotation
        Quaternion rotation = xrController.deviceRotation.ReadValue();
        transform.localRotation = rotation;
    }
}
