using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class MoveScript : MonoBehaviour
    {
        // реализация перемещения игрока

        [SerializeField] private GameObject _playerObject;

        private Vector3 _vectorMove;
        private float _turnHorizontal;
        private float _turnVertical;
        public float SpeedRun;
        private float _speed;
        private float _allowPlayerRotation = 0.1f;
        private Animator _anim;
        public bool FastSpeedRun;
        public float FastExpiration;
        [Range(0,1f)]
        private float _startAnimTime = 0.3f;
        [Range(0, 1f)]
        private float _stopAnimTime = 0.15f;
        public void Awake()
        {
            _anim = this.GetComponent<Animator> ();
        }
        
        public void Update()
        {
            _vectorMove.z = Input.GetAxis("Vertical");
            _vectorMove.x = Input.GetAxis("Horizontal");
            _speed = new Vector2(_vectorMove.x, _vectorMove.z).sqrMagnitude;

            if (FastSpeedRun)
            {
                SpeedRun = SpeedRun * 2;
                FastExpiration -= 1;
            }

            if (FastExpiration < 1)
            {
                FastSpeedRun = false;
            }
            
            
            
            
            var _move = _vectorMove * SpeedRun * Time.deltaTime;
            
            transform.Translate(_move);
            
            if (_speed > _allowPlayerRotation) {
                _anim.SetFloat ("Blend", _speed, _startAnimTime, Time.deltaTime);
            } else if (_speed < _allowPlayerRotation) {
                _anim.SetFloat ("Blend", _speed, _stopAnimTime, Time.deltaTime);
            }
            
            
            
        }
        
        


    }
}