using UnityEngine;
using UnityEngine.XR;

public class XRControllerTracking : MonoBehaviour
{
    public XRNode node;

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(node);

        if (device.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 pos))
            transform.localPosition = pos;

        if (device.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rot))
            transform.localRotation = rot;
    }
}
