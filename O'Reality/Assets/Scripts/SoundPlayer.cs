using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
     public AudioClip soundClip; // Clip de sonido a reproducir
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
    }

    public void PlaySound()
    {
        if (soundClip != null)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
        }
    }
}
