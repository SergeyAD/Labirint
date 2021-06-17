using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    public class CameraScript : MonoBehaviour
    {
        public bool shakeCamera = false;
        public float shakeDuration = 10f;
        


        public void Awake()
        {
            // Не удается подписаться на обновление информации об игроке(((((


            Player.ChangePlayerEvent += _cameraShakeChange;

            //Player.ChangePlayerEvent += _cameraShakeChange();
        }

        public void _cameraShakeChange()
        {
            shakeCamera = !shakeCamera;

        }

        public void Update()
        {
            if (shakeCamera)
            {

            }
        }


    }
}
