using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Cinemachine.Utility;

namespace SleepingPenguinz.PhaeProject.CharacterAssist
{
    /// <summary>
    /// The lockOn script is used to control the camera movement to lockon targets while still having some control on the camera
    /// You need a cinemachineFreeLook camera and normal CinemachinevirtualCamera
    /// </summary>
    public class LockOn : MonoBehaviour
    {
        [Tooltip("factor multiple for each axis when choosing target to lock, higher value = more important axis. X -> horizontal angle, Y -> vertical angle, Z -> distance")]
        public Vector3 m_TargetPriorityAxisFactor = new Vector3(1, 0.1f, 0.01f);
        public CinemachineFreeLook m_freeLookVCam;
        public CinemachineVirtualCamera m_LockOnVCam;
        public CinemachineVirtualCamera m_transitionVCam;
        public CinemachineBrain brain;
        public int m_VCamLowPriority = 0;
        public int m_VCamHighPriority = 20;
        [Tooltip("The transform that should be placed on the target")]
        public Transform m_CMTargetTransform;
        [Tooltip("The Follow transform that should be used by the Freelook camera")]
        public Transform m_CMPivotFollowTransform;
        [Tooltip("The LookAt transform that should be used by the Freelook camera")]
        public Transform m_CMPivotLookAtTransform;
        [Tooltip("The character transform that should be focused by the freelook")]
        public Transform m_Character;
        [Tooltip("How far infront of the character the freelook pivot transforms can be")]
        public float m_MaxPivotDistance;
        [Tooltip("The Y offset used for the look at pivot transform")]
        public float m_CharacterYOffset;
        [Tooltip("The delay between the last camera movement input and the camera switching to lockOn")]
        public float transitionDelay;
        [Tooltip("The angle that limits the possible targets, if target goes out of range after manual lockon, change to automatic")]
        public float m_VerticalAngleLimit = 45;
        [Tooltip("The distance that limits the possible targets, if target goes out of range after manual lockon, change to automatic")]
        public float m_TargetSqrDistanceLimit = 500;
        [Tooltip("Layers that the character cannot lockOn a target through, if lockedOn target goes behind a obstacle it waits the Obstacle unlock delay time before unlcoking the target")]
        public LayerMask m_ObstacleLayerMask;
        [Tooltip("The distance that limits the possible targets, if target goes out of range after manual lockon, change to automatic")]
        public float m_ObstacleUnlockDelay = 2;


        private Camera m_MainCamera;
        private float m_TransitionTimer = -1;
        private float m_ObstacleTimer = -1;

        private Coroutine vCamTransitionCoroutine;

        List<LockOnTarget> m_PossibleLockOnTargets;

        LockOnTarget m_CurrentTarget = null;
        bool m_ManualLockOn = false;

        private LockOnUI m_LockOnUI;

        public void AttachLockOnUI(LockOnUI lockOnUI)
        {
            m_LockOnUI = lockOnUI;
        }

        public virtual Vector2 FreeLookCameraInput()
        {
            return new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        }

        public void AddPossibleTarget(LockOnTarget target)
        {
            if (m_PossibleLockOnTargets == null) {
                m_PossibleLockOnTargets = new List<LockOnTarget>();
            }
            m_PossibleLockOnTargets.Add(target);
        }

        public void RemovePossibleTarget(LockOnTarget target)
        {
            if (m_PossibleLockOnTargets == null) { return; }
            m_PossibleLockOnTargets.Remove(target);
            if (m_CurrentTarget == target) {
                m_CurrentTarget = null;
            }
        }

        private void Start()
        {
            m_MainCamera = Camera.main;
            if (m_MainCamera == null) { Debug.LogError("Main camera is missing"); return; }

            m_transitionVCam.Priority = m_VCamLowPriority-1;
            m_LockOnVCam.Priority = m_VCamLowPriority;
        }

        private void Update()
        {
            m_CMPivotFollowTransform.position = m_Character.position;
            m_CMPivotLookAtTransform.position = m_Character.position + Vector3.up * m_CharacterYOffset;
            if (m_PossibleLockOnTargets.Count == 0 && m_LockOnVCam.Priority == m_VCamLowPriority) {  return; }

            if (Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log("lockOn!");
                TriggerManualLockOn(!m_ManualLockOn);
            }

            //If manual lock is active and currentTarget gets out of range
            if(m_CurrentTarget != null && ConsiderTarget(m_CurrentTarget) == false) {
                TriggerManualLockOn(false);
            }

            if (m_ManualLockOn) {
                ManualLockOn();
            } else {
                AutomaticLockOn();
            }

            if(m_CurrentTarget != null) {
                m_CMTargetTransform.position = m_CurrentTarget.PositionWithOffset();
            }       

        }

        private void LateUpdate()
        {
            UpdateUI();
        }


        void UpdateUI()
        {
            if (m_LockOnUI == null) { Debug.LogWarning("LockOnUI is null!"); return; }

            if (m_CurrentTarget != null) {
                Vector3 viewPortPoint = m_MainCamera.WorldToViewportPoint(m_CurrentTarget.transform.position + m_CurrentTarget.m_Offset);

                bool inScreen  = viewPortPoint.x >= 0 && viewPortPoint.x <= 1 && viewPortPoint.y >= 0 && viewPortPoint.y <= 1 &&
                viewPortPoint.z >= m_MainCamera.nearClipPlane && viewPortPoint.z <= m_MainCamera.farClipPlane;
                if (inScreen) {
                    m_LockOnUI.MoveSprite(m_ManualLockOn, viewPortPoint);
                    return;
                }
            }
            m_LockOnUI.HideSprite();
        }

        Vector3 CharacterPosWithOffset()
        {
            return m_Character.position + new Vector3(0, m_CharacterYOffset, 0);
        }

        /// <summary>
        /// Returns is target is in range. Using angle and distance limits
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        bool ConsiderTarget(LockOnTarget target)
        {
            Vector3 charToTarget = target.PositionWithOffset() - CharacterPosWithOffset();
            float angleYToTarget;
            //when to close to target ignore angle limit
            if (charToTarget.sqrMagnitude < 2) {
                angleYToTarget = 0;
            } else {
                angleYToTarget = Mathf.Asin(charToTarget.normalized.y) * Mathf.Rad2Deg;
            }

            return Mathf.Abs(angleYToTarget) <= m_VerticalAngleLimit && charToTarget.sqrMagnitude <= m_TargetSqrDistanceLimit;
        }

        /// <summary>
        /// 0..inf, inf -> high prioroty, 0 -> low priority
        /// This priority can be affected with the m_TargetPriorityAxisFactor
        /// </summary>
        float TargetPriority(LockOnTarget target)
        {
            Vector3 charToTarget = target.PositionWithOffset() - CharacterPosWithOffset();
            Vector3 charToTargetNormalized = charToTarget.normalized;

            float angleVerticalToTarget = Mathf.Asin(Mathf.Abs(Vector3.Dot(charToTargetNormalized, -m_MainCamera.transform.up))) * Mathf.Rad2Deg; //0-180, 0 far, 180 close
            float angleHorizontalToTarget = Mathf.Asin(Mathf.Abs(Vector3.Dot(charToTargetNormalized, -m_MainCamera.transform.forward))) * Mathf.Rad2Deg; //0-180, 0 far, 180 close

            float sqrDistance = Mathf.Clamp(charToTarget.sqrMagnitude,float.Epsilon, float.MaxValue);

            float priority = m_TargetPriorityAxisFactor.x * angleHorizontalToTarget + m_TargetPriorityAxisFactor.y * angleVerticalToTarget + m_TargetPriorityAxisFactor.z / sqrDistance;

            return priority;
        }

        bool ObstaclesInfrontTarget(LockOnTarget target)
        {
            RaycastHit hit;
            Vector3 dir = target.PositionWithOffset() - CharacterPosWithOffset();
            float dist = dir.magnitude;
            if (Physics.Raycast(CharacterPosWithOffset(), dir, out hit, dist, m_ObstacleLayerMask)) {
                if(hit.collider.gameObject != target.gameObject) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// High priority target is closer to the center of the screen.
        /// This priority can be affected with the m_TargetPriorityAxisFactor
        /// </summary>
        /// <param name="requireOnScreen"></param>
        /// <returns></returns>
        LockOnTarget FindTargetWithHighestPriority(bool requireOnScreen)
        {
            int targetIndex = -1;
            float targetPriority = 0;
            for (int i = 0; i < m_PossibleLockOnTargets.Count; i++) {

                
                bool considerTarget = ConsiderTarget(m_PossibleLockOnTargets[i]);
                //On screen?
                if (requireOnScreen && considerTarget) {
                    Vector3 viewPortPoint = m_MainCamera.WorldToViewportPoint(m_PossibleLockOnTargets[i].transform.position + m_PossibleLockOnTargets[i].m_Offset);

                    considerTarget = viewPortPoint.x >= 0 && viewPortPoint.x <= 1 && viewPortPoint.y >= 0 && viewPortPoint.y <= 1 &&
                    viewPortPoint.z >= m_MainCamera.nearClipPlane && viewPortPoint.z <= m_MainCamera.farClipPlane;
                }

                if (considerTarget) {
                    float possibleTargetPriority = TargetPriority(m_PossibleLockOnTargets[i]);
                    if (possibleTargetPriority >= targetPriority) {
                        if(ObstaclesInfrontTarget(m_PossibleLockOnTargets[i]) == false) {
                            targetIndex = i;
                            targetPriority = possibleTargetPriority;
                        }
                    }

                }
            }
            if (targetIndex == -1) {
                return null;
            } else {
                return m_PossibleLockOnTargets[targetIndex];
            }
        }

        void ManualLockOn()
        {
            Vector3 vectorToTarget = (m_CurrentTarget.PositionWithOffset() - CharacterPosWithOffset()) / 2;
            Vector3 vectorToTargetIgnoreY = new Vector3(vectorToTarget.x, m_Character.position.y, vectorToTarget.z);

            float sqrMaxPivotDistance = m_MaxPivotDistance * m_MaxPivotDistance;

            if (Vector3.SqrMagnitude(vectorToTarget) > sqrMaxPivotDistance) {
                vectorToTarget = vectorToTarget.normalized * m_MaxPivotDistance;
            }
            if (Vector3.SqrMagnitude(vectorToTargetIgnoreY) > sqrMaxPivotDistance) {
                vectorToTargetIgnoreY = vectorToTargetIgnoreY.normalized * m_MaxPivotDistance;
            }
            m_CMPivotFollowTransform.position += vectorToTargetIgnoreY;
            m_CMPivotFollowTransform.LookAt(m_CurrentTarget.PositionWithOffset());
            m_CMPivotLookAtTransform.position += vectorToTarget;
            m_CMPivotLookAtTransform.LookAt(m_CurrentTarget.PositionWithOffset());


            //obstacle timer
            if (m_ObstacleTimer >= 0) {
                m_ObstacleTimer -= Time.deltaTime;
                if (m_ObstacleTimer < 0) {
                    m_ManualLockOn = false;
                    m_ObstacleTimer = -1;
                } else if(ObstaclesInfrontTarget(m_CurrentTarget) == false) {
                    m_ObstacleTimer = -1;
                }
            } else if(ObstaclesInfrontTarget(m_CurrentTarget)) {
                m_ObstacleTimer = m_ObstacleUnlockDelay;
            }

            //input timer for camera transition
            Vector2 cameraInput = FreeLookCameraInput();
            if (Mathf.Abs(cameraInput.x) > 0.1f || Mathf.Abs(cameraInput.y) > 0.1f) {
                if (m_TransitionTimer < 0) {
                    //camera to lockOn
                    if (vCamTransitionCoroutine != null) { StopCoroutine(vCamTransitionCoroutine); Debug.LogWarning("Thecoroutine should take less time than transition delay!!!"); }
                    
                    vCamTransitionCoroutine = StartCoroutine(LockOnToFreeLooktransition());
                }
                m_TransitionTimer = transitionDelay;
            }
            if (m_TransitionTimer >= 0) {
                m_TransitionTimer -= Time.deltaTime;
                if (m_TransitionTimer < 0) {
                    if (vCamTransitionCoroutine != null) { StopCoroutine(vCamTransitionCoroutine); Debug.LogWarning("Thecoroutine should take less time than transition delay!!! 2"); }
                    vCamTransitionCoroutine = StartCoroutine(FreeLookToLockOntransition());
                }
            }
        }

        IEnumerator FreeLookToLockOntransition()
        {
            while (brain.IsLive(m_freeLookVCam) && brain.IsBlending) { // needs to take less time then transitionDelay
                yield return null;
            }
            m_transitionVCam.transform.position = m_freeLookVCam.State.RawPosition;
            m_transitionVCam.transform.rotation = m_freeLookVCam.State.RawOrientation;
            m_transitionVCam.Priority = m_VCamHighPriority + 1;
            yield return null;
            while (brain.IsLive(m_freeLookVCam)) { // needs to take less time then transitionDelay
                yield return null;
            }
            m_transitionVCam.Priority = m_VCamLowPriority -1;
            m_LockOnVCam.Priority = m_VCamHighPriority;
            vCamTransitionCoroutine = null;
        }

        IEnumerator LockOnToFreeLooktransition()
        {
            while (brain.IsLive(m_freeLookVCam)) { // needs to take less time then transitionDelay
                yield return null;
            }

            m_freeLookVCam.m_YAxis.Value = GetYAxisClosestValue(m_freeLookVCam, brain.CurrentCameraState.RawPosition, brain.DefaultWorldUp);
            m_freeLookVCam.m_XAxis.Value = GetXAxisClosestValue(m_freeLookVCam, brain.CurrentCameraState.RawPosition, brain.DefaultWorldUp);

            m_transitionVCam.Priority = m_VCamLowPriority - 1;
            m_LockOnVCam.Priority = m_VCamLowPriority;

            yield return null;
            while (brain.IsBlending) { // needs to take less time then transitionDelay
                yield return null;
            }
            //m_freeLookVCam.m_Transitions.m_InheritPosition = true;
            vCamTransitionCoroutine = null;

        }

        void TriggerManualLockOn(bool active)
        {
            if (!active) {
                m_ManualLockOn = false;
                return;
            }

            if(m_CurrentTarget != null) {
                m_ManualLockOn = true;
                m_LockOnVCam.Priority = m_VCamHighPriority;
                return;
            }

            m_CurrentTarget = FindTargetWithHighestPriority(false);

            if (m_CurrentTarget != null) {
                m_ManualLockOn = true;
                m_LockOnVCam.Priority = m_VCamHighPriority;
            }
        }

        void AutomaticLockOn()
        {
            m_CurrentTarget = FindTargetWithHighestPriority(true);
            if(m_LockOnVCam.Priority != m_VCamLowPriority && vCamTransitionCoroutine == null) {
                if (vCamTransitionCoroutine != null) { StopCoroutine(vCamTransitionCoroutine); Debug.LogError("Thecoroutine should take less time than transition delay!!!"); }
                vCamTransitionCoroutine = StartCoroutine(LockOnToFreeLooktransition());
            }
        }



        float GetYAxisClosestValue(CinemachineFreeLook freeLook, Vector3 cameraPos, Vector3 up)
        {
            if (freeLook.Follow != null) {
                // Rotate the camera pos to the back
                Quaternion q = Quaternion.FromToRotation(up, Vector3.up);
                Vector3 dir = q * (cameraPos - freeLook.Follow.position);
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
                        dir, freeLook.GetLocalPositionForCameraFromInput(i * step), Vector3.right);
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
            return freeLook.m_YAxis.Value; // stay conservative
        }

        float GetXAxisClosestValue(CinemachineFreeLook freeLook, Vector3 cameraPos, Vector3 up)
        {
            Quaternion orient = GetReferenceOrientation(freeLook, up);
            Vector3 fwd = (orient * Vector3.forward).ProjectOntoPlane(up);
            if (!fwd.AlmostZero() && freeLook.Follow != null) {
                // Get the base camera placement
                float heading = 0;
                if (freeLook.m_BindingMode != CinemachineTransposer.BindingMode.SimpleFollowWithWorldUp)
                    heading += freeLook.m_Heading.m_Bias;
                orient = orient * Quaternion.AngleAxis(heading, up);
                Vector3 targetPos = freeLook.Follow.position;
                Vector3 pos = targetPos + orient * EffectiveOffset(freeLook);

                Vector3 a = (pos - targetPos).ProjectOntoPlane(up);
                Vector3 b = (cameraPos - targetPos).ProjectOntoPlane(up);
                return Vector3.SignedAngle(a, b, up);
            }
            return freeLook.m_XAxis.Value; // Can't calculate, stay conservative
        }

        Quaternion GetReferenceOrientation(CinemachineFreeLook freeLook, Vector3 worldUp)
        {
            if (freeLook.Follow != null) {
                Quaternion targetOrientation = freeLook.Follow.rotation;
                switch (freeLook.m_BindingMode) {
                //case CinemachineTransposer.BindingMode.LockToTargetOnAssign:
                //    return m_targetOrientationOnAssign;
                //case CinemachineTransposer.BindingMode.LockToTargetWithWorldUp:
                //    return Uppify(targetOrientation, worldUp);
                case CinemachineTransposer.BindingMode.LockToTargetNoRoll:
                    return Quaternion.LookRotation(targetOrientation * Vector3.forward, worldUp);
                case CinemachineTransposer.BindingMode.LockToTarget:
                    return targetOrientation;
                case CinemachineTransposer.BindingMode.SimpleFollowWithWorldUp: {
                    Vector3 dir = freeLook.Follow.position - freeLook.State.RawPosition;
                    dir = dir.ProjectOntoPlane(worldUp);
                    if (dir.AlmostZero())
                        break;
                    return Quaternion.LookRotation(dir.normalized, worldUp);
                }
                default:
                    break;
                }
            }
            return Quaternion.identity;
        }

        Vector3 EffectiveOffset(CinemachineFreeLook freeLook)
        {
            Vector3 offset = freeLook.State.RawPosition - freeLook.Follow.position;
            if (freeLook.m_BindingMode == CinemachineTransposer.BindingMode.SimpleFollowWithWorldUp) {
                offset.x = 0;
                offset.z = -Mathf.Abs(offset.z);
            }
            return offset;
        }
    }
}