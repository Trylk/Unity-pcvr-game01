using UnityEngine;

public class CliffSoundTrigger : MonoBehaviour
{
    public AudioSource growl;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !growl.isPlaying)
            growl.Play();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            growl.Stop();
    }
}
