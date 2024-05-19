using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ArtilleryShell : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private int _damage;
    private Transform _playerTransform;
    private float _attackDistance;
    private LayerMask _layerMask;

    private Vector3 _constantPosition;
    private Vector3 _shotPosition;

    private bool _shot = false;

    private float _timer = 0f;





    private void Start()
    {
        _particleSystem.Play();
        _shot = true;
        _shotPosition = _playerTransform.position;

        Destroy(gameObject, 2f);
    }



    public void Setup(int damage, float attackDistance, Vector3 constantPosition, LayerMask layerMask, Player player)
    {
        _damage = damage;
        _attackDistance = attackDistance;
        _constantPosition = constantPosition;
        _layerMask = layerMask;
        _playerTransform = player.transform;

    }
    private void Update()
    {
        if (transform.position != _constantPosition)
        {
            transform.position = _constantPosition;
        }

        transform.LookAt(_playerTransform, Vector3.up);


        if (_shot)
        {
            _timer += Time.deltaTime;

        }

        if (_timer > 1f)
        {
            HitEnemies();
        }


    }



    private void HitEnemies()
    {

        Collider[] colliders = Physics.OverlapSphere(_shotPosition, _attackDistance, _layerMask);
        foreach (Collider collider in colliders)
        {
            if (collider?.GetComponent<Enemy>() is Enemy enemy)
            {

                enemy.SetDamage(_damage);
               
            }
        }
    }




}
