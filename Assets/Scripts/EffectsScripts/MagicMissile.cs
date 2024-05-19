using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissile : MonoBehaviour
{
    private Enemy _targetEnemy;
    private float _speed;
    private int _damage;

    public void Setup(Enemy targetEnemy, int damage, float speed)
    {
        _damage = damage;
        _targetEnemy = targetEnemy;
        _speed = speed;
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        if (_targetEnemy)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetEnemy.transform.position, _speed * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, _targetEnemy.transform.position);
            if (distance < 1f)
            {
                AffectEnemy();
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void AffectEnemy()
    {
        _targetEnemy.SetDamage(_damage);
    }
}
