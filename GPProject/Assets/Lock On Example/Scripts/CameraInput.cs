using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraInput : MonoBehaviour
{
    public CinemachineFreeLook freeLookVCam;

    private void Update()
    {

        float xInput = Input.GetAxisRaw("Mouse X");
        float yInput = Input.GetAxisRaw("Mouse Y");

        freeLookVCam.m_XAxis.m_InputAxisValue = xInput;
        freeLookVCam.m_YAxis.m_InputAxisValue = yInput;
        
    }
}
