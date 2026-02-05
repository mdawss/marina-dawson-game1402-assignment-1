using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    
    //null check and functionality to play a one shot audio clip when autorized.
    public void PlaySound(AudioClip clip)
    {
        if (clip == null) return;
        audioSource.PlayOneShot(clip);
    }
}
