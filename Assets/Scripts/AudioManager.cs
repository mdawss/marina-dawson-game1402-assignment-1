using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
