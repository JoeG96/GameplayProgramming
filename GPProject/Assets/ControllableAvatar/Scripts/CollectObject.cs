using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    public AudioSource collectSound;
    ParticleSystem particles;

    private void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        Destroy(gameObject);
    }
}
