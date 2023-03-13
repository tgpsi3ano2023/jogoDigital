using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class AudioClips : MonoBehaviour
{
    public Vector3 point;
    public AudioClip[] Clip;
    AudioSource aud;
    float delay_time = 0f;


    async void Start()
    {

        aud = GetComponent<AudioSource>();
        foreach (AudioClip n in Clip)
        {
            await Task.Delay((int)delay_time * 1000); //Task.Delay input is in milliseconds
            playaudio(n);

        }
    }

    void playaudio(AudioClip n)
    {
        aud.clip = n;
        aud.Play();
        delay_time = n.length + 1;//1 second is added to cater for the loading delay          

    }
}
