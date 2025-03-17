using System;
using UnityEngine;

namespace GameContent.Scripts.Player
{
    public class DashingObject : MonoComponent
    {
        public event Action DashEnds;

        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private float _dashForce = 5f;
        [SerializeField] private float _dashDuration = 0.2f;

        private float _value = 0f;
        private Vector3 _startPos;
        private Vector3 _endPos;
        private bool _isDashing = false;

        private void FixedUpdate()
        {
            if (_isDashing == false) return;

            _value += Time.deltaTime;

            _rigidbody.velocity = (_endPos - _startPos) * _dashForce;

            if (_value >= _dashDuration)
            {
                _rigidbody.velocity = Vector3.zero;
                _isDashing = false;
                DashEnds?.Invoke();
            }
        }

        public void Dash(Vector3 dashDirection)
        {
            _startPos = transform.position;
            _endPos = transform.position + dashDirection * _dashForce;
            _value = 0f;
            _isDashing = true;
        }
    }
}