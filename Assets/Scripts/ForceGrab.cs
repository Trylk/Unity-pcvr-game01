using UnityEngine;


public class ForceGrab : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor hand;
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;

    void Update()
    {
        if (hand == null || grab == null) return;

        if (!grab.isSelected)
        {
            hand.interactionManager.SelectEnter(
                (UnityEngine.XR.Interaction.Toolkit.Interactors.IXRSelectInteractor)hand,
                (UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable)grab
            );
        }
    }
}
