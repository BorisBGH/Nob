using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Vector2 _moveInput;
    [SerializeField] private Animator _animator;
    

   
    void Update()
    {
        _moveInput = _joystick.Value;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_moveInput.x, 0f, _moveInput.y);
    }
}
