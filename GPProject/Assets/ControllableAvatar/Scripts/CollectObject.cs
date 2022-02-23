using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    public AudioSource collectSound;
    ParticleSystem particles;

    private void Awake()
    {
        particles = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        particles.Play();
        Destroy(gameObject, 1);
    }

}
