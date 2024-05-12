using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _roationLerpRate;
    [SerializeField] private PlayerHealth _playerHealth;

    [SerializeField] private int _health = 50;
    [SerializeField] private GameObject _dieEffect;

    private float _attackTimer;
    [SerializeField] private float _attackPeriod = 1f;
    [SerializeField] private float _damagePerSec;

    private EnemyManager _enemyManager;
    private bool _isDead;

    public void Init(Transform playerTransform, EnemyManager enemyManager)
    {
        _playerTransform = playerTransform;
        _enemyManager = enemyManager;
    }

    private void Update()
    {
        if (_playerHealth)
        {
            _attackTimer += Time.deltaTime;
            if (_attackTimer > _attackPeriod)
            {
                _playerHealth.TakeDamage(_damagePerSec * _attackPeriod);
                _attackTimer = 0f;
            }
        }
    }

    void FixedUpdate()
    {
        if (_playerTransform)
        {
            Vector3 toPlayer = _playerTransform.position - transform.position;
            Quaternion toPlayerRotation = Quaternion.LookRotation(toPlayer, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toPlayerRotation, Time.deltaTime * _roationLerpRate);
            _rigidbody.velocity = transform.forward * _speed;

            if (toPlayer.magnitude > 20f)
            {
                transform.position += toPlayer * 1.95f;
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() is PlayerHealth playerHealth)
        {
            _playerHealth = playerHealth;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            _playerHealth = null;
        }
    }

    public void SetDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!_isDead)
        {
            Instantiate(_dieEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            _enemyManager.RemoveEnemy(this);
            Destroy(gameObject, 1f);
            _isDead = true;
        }
       
    }
}
