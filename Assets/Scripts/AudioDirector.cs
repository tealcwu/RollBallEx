using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDirector : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip GlassBreak1;
    public AudioClip GlassBreak2;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGlassBreak1()
    {
        audioSource.PlayOneShot(GlassBreak1);
    }

    public void PlayGlassBreak2()
    {
        audioSource.PlayOneShot(GlassBreak2);
    }
}
