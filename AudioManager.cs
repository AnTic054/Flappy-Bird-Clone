using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManagerinstance;
    public AudioSource audioManager;
    public AudioClip music;
    private void Awake()
    {
        if (audioManagerinstance != null && audioManagerinstance != this)
        {
            Destroy(this);
        }
        else
        {
            audioManagerinstance = this;
        }
        audioManager.PlayOneShot(music);
    }
    public void PlayOneShot(AudioClip soundClip)
    {
        audioManager.PlayOneShot(soundClip);
    }
}
