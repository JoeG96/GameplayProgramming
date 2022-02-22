using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStamina : MonoBehaviour
{
    new AudioSource audio;
    public AudioClip collectSound;
    ParticleSystem particles;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();

        //particles = GetComponent<ParticleSystem>();
        //particles.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        //audio.Play();

        //particles.Play();
        Destroy(gameObject);
    }
}
