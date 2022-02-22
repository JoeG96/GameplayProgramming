using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private ParticleSystem particle;
    PlayerLocomotion playerLocomotion;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerLocomotion.doubleJumpEnable = true;
            Debug.Log("Double Jump Enable Status" + playerLocomotion.doubleJumpEnable);
        }
    }
}
