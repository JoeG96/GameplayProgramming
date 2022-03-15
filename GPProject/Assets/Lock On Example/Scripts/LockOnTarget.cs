using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SleepingPenguinz.PhaeProject.CharacterAssist
{
    public class LockOnTarget : MonoBehaviour
    {
        public Vector3 m_Offset;

        private LockOn m_PlayerLockOn;

        private void OnEnable()
        {
            if(m_PlayerLockOn == null) { m_PlayerLockOn = Camera.main.GetComponent<LockOn>(); }
            m_PlayerLockOn.AddPossibleTarget(this);
        }

        private void OnDisable()
        {
            m_PlayerLockOn.RemovePossibleTarget(this);
        }

        public Vector3 PositionWithOffset()
        {
            return transform.position + m_Offset;
        }
    }
}