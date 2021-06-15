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

        private Vector3 _vector;
        private float _turn;
        private float _turnHorizontal;
        private float _turnVertical;
        public float SpeedRun;
        public float SpeedTurn;
        private float _speed;
        private float _allowPlayerRotation = 0.1f;
        private Animator _anim;
        public bool FastSpeedRun;
        public float FastExpiration;
        private Rigidbody _rb;

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

            if (FastSpeedRun)
            {
                FastExpiration -= 1;
            }

            if (FastExpiration < 1)
            {
                FastSpeedRun = false;
            }

        }

        public void FixedUpdate()
        {
            _vector.z = Input.GetAxis("Vertical");
            _turn = Input.GetAxis("Horizontal");
            var _sr = FastSpeedRun ? SpeedRun : SpeedRun * 2;
            var _st = FastSpeedRun ? SpeedTurn : SpeedTurn * 2;

            var _move = _vector * _sr * Time.fixedDeltaTime;
            var turn = _turn *_st * Time.fixedDeltaTime;

            transform.Translate(_move);
            transform.Rotate(new Vector3(0, turn, 0));

            _speed = new Vector2(0, _vector.z).sqrMagnitude;
            if (_speed > _allowPlayerRotation)
            {
                _anim.SetFloat("Blend", _speed, _startAnimTime, Time.deltaTime);
            }
            else if (_speed < _allowPlayerRotation)
            {
                _anim.SetFloat("Blend", _speed, _stopAnimTime, Time.deltaTime);
            }
        }




    }
}