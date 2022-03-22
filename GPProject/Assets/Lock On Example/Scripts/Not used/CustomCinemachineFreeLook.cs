/*using UnityEngine;
using Cinemachine;
using Cinemachine.Utility;

namespace SleepingPenguinz.PhaeProject.CharacterAssist
{
    public class CustomCinemachineFreeLook : CinemachineFreeLook
    {
        
        /// <summary>If we are transitioning from another FreeLook, grab the axis values from it.</summary>
        /// <param name="fromCam">The camera being deactivated.  May be null.</param>
        /// <param name="worldUp">Default world Up, set by the CinemachineBrain</param>
        /// <param name="deltaTime">Delta time for time-based effects (ignore if less than or equal to 0)</param>
        public override void OnTransitionFromCamera(
            ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime)
        {
            base.OnTransitionFromCamera(fromCam, worldUp, deltaTime);
            bool forceUpdate = false;
            if (fromCam != null && m_Transitions.m_InheritPosition) {
                var cameraPos = fromCam.State.RawPosition;
                UpdateRigCache();
                if (m_BindingMode != CinemachineTransposer.BindingMode.SimpleFollowWithWorldUp)
                    m_XAxis.Value = mOrbitals[1].GetAxisClosestValue(cameraPos, worldUp);
                m_YAxis.Value = GetYAxisClosestValue(cameraPos, worldUp);

                transform.position = cameraPos;
                m_State = PullStateFromVirtualCamera(worldUp, ref m_Lens);
                PreviousStateIsValid = false;
                PushSettingsToRigs();
                forceUpdate = true;
            }
            if (forceUpdate)
                InternalUpdateCameraState(worldUp, deltaTime);
            else
                UpdateCameraState(worldUp, deltaTime);
            if (m_Transitions.m_OnCameraLive != null)
                m_Transitions.m_OnCameraLive.Invoke(this, fromCam);
        }

        float GetYAxisClosestValue(Vector3 cameraPos, Vector3 up)
        {
            if (Follow != null) {
                // Rotate the camera pos to the back
                Quaternion q = Quaternion.FromToRotation(up, Vector3.up);
                Vector3 dir = q * (cameraPos - Follow.position);
                Vector3 flatDir = dir; flatDir.y = 0;
                if (!flatDir.AlmostZero()) {
                    float angle = Vector3.SignedAngle(flatDir, Vector3.back, Vector3.up);
                    dir = Quaternion.AngleAxis(angle, Vector3.up) * dir;
                }
                dir.x = 0;

                // Sample the spline in a few places, find the 2 closest, and lerp
                int i0 = 0, i1 = 0;
                float a0 = 0, a1 = 0;
                const int NumSamples = 13;
                float step = 1f / (NumSamples - 1);
                for (int i = 0; i < NumSamples; ++i) {
                    float a = Vector3.SignedAngle(
                        dir, GetLocalPositionForCameraFromInput(i * step), Vector3.right);
                    if (i == 0)
                        a0 = a1 = a;
                    else {
                        if (Mathf.Abs(a) < Mathf.Abs(a0)) {
                            a1 = a0;
                            i1 = i0;
                            a0 = a;
                            i0 = i;
                        } else if (Mathf.Abs(a) < Mathf.Abs(a1)) {
                            a1 = a;
                            i1 = i;
                        }
                    }
                }
                if (Mathf.Sign(a0) == Mathf.Sign(a1))
                    return i0 * step;
                float t = Mathf.Abs(a0) / (Mathf.Abs(a0) + Mathf.Abs(a1));
                return Mathf.Lerp(i0 * step, i1 * step, t);
            }
            return m_YAxis.Value; // stay conservative
        }

        /// <summary>
        /// What axis value would we need to get as close as possible to the desired cameraPos?
        /// </summary>
        /// <param name="cameraPos">camera position we would like to approximate</param>
        /// <param name="up">world up</param>
        /// <returns>The best value to put into the X axis, to approximate the desired camera pos</returns>
        public float GetAxisClosestValue(Vector3 cameraPos, Vector3 up)
        {
            Quaternion orient = GetReferenceOrientation(up);
            Vector3 fwd = (orient * Vector3.forward).ProjectOntoPlane(up);
            if (!fwd.AlmostZero() && Follow != null) {
                // Get the base camera placement
                float heading = 0;
                if (m_BindingMode != CinemachineTransposer.BindingMode.SimpleFollowWithWorldUp)
                    heading += m_Heading.m_Bias;
                orient = orient * Quaternion.AngleAxis(heading, up);
                Vector3 targetPos = Follow.position;
                Vector3 pos = targetPos + orient * EffectiveOffset;

                Vector3 a = (pos - targetPos).ProjectOntoPlane(up);
                Vector3 b = (cameraPos - targetPos).ProjectOntoPlane(up);
                return Vector3.SignedAngle(a, b, up);
            }
            return LastHeading; // Can't calculate, stay conservative
        }

    }
}*/