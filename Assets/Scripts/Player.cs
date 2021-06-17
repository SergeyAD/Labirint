using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class Player : MonoBehaviour//MoveScript
    {
        // Общий класс игрока
        public int Lives;
        public int BonusCount;
        private bool _isFastSpeed;


        public delegate void ChangePlayer();

        public event ChangePlayer ChangePlayerEvent;

        private void Awake()
        {
        Lives = 3;
        BonusCount = 0;
        }
        


        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BonusPointScript _point))
            {
            BonusCount += _point.BonusCount;
            _point.BonusCount = 0;
            Lives -= _point.Damage;
            _point.Damage = 0;
                if (_point.FastSpeed)
                {
                    if (TryGetComponent(out MoveScript _move))
                    {
                        _move.FastSpeedRun = true;
                        _move.FastExpiration += 1000;
                        
                    }
                    _point.FastSpeed = false;
                }
            ChangePlayerEvent?.Invoke();

            Destroy(other.gameObject);

            }

            
        }







    }
}