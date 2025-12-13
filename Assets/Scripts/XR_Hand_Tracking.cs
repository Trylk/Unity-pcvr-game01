using UnityEngine;
using UnityEngine.XR;

public class XRI_Hand_Tracking : MonoBehaviour
{
    public XRNode handNode = XRNode.RightHand;

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(handNode);

        if (!device.isValid)
            return;

        if (device.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 pos))
            transform.localPosition = pos;

        if (device.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rot))
            transform.localRotation = rot;
    }
}
