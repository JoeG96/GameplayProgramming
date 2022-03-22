using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{

    [Header("Cameras")]
    [SerializeField] CinemachineFreeLook freeLookCam;
    [SerializeField] CinemachineVirtualCamera lockOnCam;

    private void Awake()
    {
        
    }

    public void SwitchCamera()
    {

    }
}
