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
            Lives -= _point.Damage;
            if (_point.FastSpeed)
            {
                if (other.TryGetComponent(out MoveScript _move))
                {
                    _move.FastSpeedRun = true;
                    _move.FastExpiration += 100 * Time.deltaTime;
                }
            }

                DestroyObject(other);

            }

            
        }


    }
}