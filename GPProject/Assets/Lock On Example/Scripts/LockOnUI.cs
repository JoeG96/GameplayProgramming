using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SleepingPenguinz.PhaeProject.CharacterAssist
{
    public class LockOnUI : MonoBehaviour
    {
        public Sprite automaticLockOnSprite;
        public Sprite manualLockOnSprite;

        public Image lockOnImage;

        private void OnEnable()
        {
            Camera.main.GetComponent<LockOn>().AttachLockOnUI(this);
        }
        
        public void MoveSprite(bool manualLock, Vector3 viewPortpos)
        {
            lockOnImage.enabled = true;
            if(manualLock && lockOnImage.sprite == automaticLockOnSprite)
            {
                lockOnImage.sprite = manualLockOnSprite;
            }
            else if(!manualLock && lockOnImage.sprite == manualLockOnSprite)
            {
                lockOnImage.sprite = automaticLockOnSprite;
            }

            Vector2 screenpos = new Vector2(viewPortpos.x * 1920 - 960, viewPortpos.y * 1080 - 540);

            lockOnImage.rectTransform.anchoredPosition = screenpos;
        }

        public void HideSprite()
        {
            lockOnImage.enabled = false;
        }
    }
}
