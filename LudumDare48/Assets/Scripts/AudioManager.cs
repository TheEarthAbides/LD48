using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip bomb;
    public AudioClip hit;
    public AudioClip bubble;
    public AudioClip shoot;
    private AudioSource sfx;
    // Start is called before the first frame update

     void Awake()
    {
        sfx = GetComponent<AudioSource>();
        instance = this;
    }

    public void PlayClip(AudioClip name, float vol)
    {
        sfx.clip = name;
        sfx.volume = vol;
        sfx.pitch = Random.Range(0.9f, 1.1f);
        sfx.Play();
    }
}
