using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchToSplineX : MonoBehaviour
{

    [Header("Cameras")]
    [SerializeField] CinemachineFreeLook freeLookCam;
    [SerializeField] CinemachineVirtualCamera splineCam;

    [Header("Player")]
    [SerializeField] GameObject playerObject;
    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = playerObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            splineCam.Priority = 11;
            rigidBody.constraints =  RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX /*| RigidbodyConstraints.FreezePositionZ*/;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            splineCam.Priority = 0;
            rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
        }    
    }

}
