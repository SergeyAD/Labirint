using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    public class CameraScript : MonoBehaviour
    {
        public bool ShakeCamera = false;
        public float ShakeDuration = 10f;
        


        public void Awake()
        {
            // Не удается подписаться на обновление информации об игроке(((((
            //вариант 1
            //Player.ChangePlayer _changePlayerEvent = new Player.ChangePlayer();
            //_changePlayerEvent += _cameraShakeChange;
            //вариант 2
            //Player.ChangePlayerEvent += _cameraShakeChange;
            //вариант 3
           


        }

        public void _cameraShakeChange()
        {
            ShakeCamera = !ShakeCamera;

        }

        public void Update()
        {
            if (ShakeCamera)
            {

            }
        }


    }
}
