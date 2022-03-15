using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace SleepingPenguinz.PhaeProject.CharacterAssist
{
    public class CinemachineFreeLookLookAtExtension : CinemachineExtension
    {
        public Transform lookAtTarget;
        public CinemachineFreeLook freeLookVCam;
        public Vector2 axisSpeed = new Vector2(2, 4);
        public Vector2 axisThreshold = new Vector2(0.005f, 0.005f);
        public Vector2 axisDamp = new Vector2(3, 2);

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (freeLookVCam == null) { Debug.LogError("this extension only works on freelook vcams"); return; }
            if (lookAtTarget == null) { return; }

            Vector3 wantedLookDirection = (lookAtTarget.position - transform.position).normalized;
            Vector3 currentLookDirection = Camera.main.transform.forward;

            //Vector3 normal = Vector3.Cross(currentLookDirection, wantedLookDirection);
            //float cosAngle = Vector3.Dot(currentLookDirection, wantedLookDirection);

            //var rotate = Quaternion.LookRotation(wantedLookDirection);

            //Debug.DrawRay(transform.position, currentLookDirection, Color.blue);
            //Debug.DrawRay(transform.position, wantedLookDirection, Color.red);

            Vector3 LookDirX = Vector3.ProjectOnPlane(wantedLookDirection, Vector3.up);
            //Debug.DrawRay(transform.position, LookDirX, Color.magenta);
            float x_angle = Vector3.SignedAngle(currentLookDirection, LookDirX, Vector3.up);//model from Blender

            Vector3 LookDirY = Vector3.ProjectOnPlane(wantedLookDirection, Vector3.right);
            //Debug.DrawRay(transform.position, LookDirY, Color.yellow);
            float y_angle = Vector3.SignedAngle(currentLookDirection, LookDirY, Vector3.right);//model from Blender



            //Debug.DrawLine(transform.position, wantedLookDirection + transform.position,Color.blue,0.01f);
            //Debug.DrawLine(transform.position, currentLookDirection + transform.position, Color.red, 0.01f);

            //float diffX = (currentLookDirection.x - wantedLookDirection.x) + (currentLookDirection.z - wantedLookDirection.z);
            //float diffY = (currentLookDirection.y - wantedLookDirection.y);


            //float horizontalMovement = diffX * diffX* diffX;
            //float verticalMovement = diffY* diffY* diffY;
            //Debug.Log(x_angle);
            float x_angle_divided = x_angle / 180f; //0-1
            float y_angle_divided = y_angle / 180f; //0-1

            float x_angle_damped = DampAbs(x_angle_divided, axisDamp.x);
            float y_angle_damped = DampAbs(y_angle_divided, axisDamp.y);

            float x_angle_speedup = x_angle_damped * axisSpeed.x;
            float y_angle_speedup = y_angle_damped * axisSpeed.y;

            float sqrDistanceToTarget = (lookAtTarget.position - transform.position).sqrMagnitude;

            float threshlodX = Mathf.Clamp(axisThreshold.x / (x_angle_divided *sqrDistanceToTarget), axisThreshold.x, 90);
            float threshlodY = Mathf.Clamp(axisThreshold.y / (y_angle_divided * sqrDistanceToTarget), axisThreshold.y, 90);

            //Debug.LogFormat("clamp: {0}",threshlodX);
            //Debug.LogFormat("speed: {0}", x_angle_speedup);

            float horizontalMovement = ThresholdAbs(x_angle_speedup, threshlodX);
            float verticalMovement = ThresholdAbs(y_angle_speedup, threshlodY);

            freeLookVCam.m_XAxis.m_InputAxisValue += horizontalMovement;
            freeLookVCam.m_YAxis.m_InputAxisValue += verticalMovement;

        }

        float ThresholdAbs(float a, float t)
        {
            if(Mathf.Abs(a) < t)
            {
                return 0;
            }
            return a;
        }

        float DampAbs(float a, float d)
        {
            float aAbs = Mathf.Clamp(Mathf.Abs(a), 0, 1);
            float inv = 1 - aAbs;

            return a/(inv*inv*d);
        }
    }

}
