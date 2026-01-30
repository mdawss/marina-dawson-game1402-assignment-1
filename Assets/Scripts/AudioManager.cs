using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    
    public void PlaySound(AudioClip clip)
    {
        if (clip == null) return;
        audioSource.PlayOneShot(clip);
    }
}
