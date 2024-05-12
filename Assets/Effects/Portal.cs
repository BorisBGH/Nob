using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private float _speed;
    private int _damage;
    private float _distance;
    private float _enemySpeedToPortal;
    LayerMask _layerMask;

    private Enemy _enemy;

    private float _lifeTime;
    private float _timer;

    public void Setup(float speed, float distance, float enemySpeedToPortal, float lifeTime, int damage, LayerMask layerMask)
    {
        _speed = speed;
        _damage = damage;
        _distance = distance;
        _enemySpeedToPortal = enemySpeedToPortal;
        _layerMask = layerMask;
        _lifeTime = lifeTime;

    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _distance, _layerMask, QueryTriggerInteraction.Ignore);
        foreach (Collider collider in colliders)
        {

            if (collider?.GetComponent<Enemy>() is Enemy enemy)
            {
                _enemy = enemy;
                Debug.Log("ENEMNY near portal");
                _enemy.transform.position = Vector3.Lerp(enemy.transform.position, transform.position, _enemySpeedToPortal);
                Invoke(nameof(HitEnemy), 2f);

            }
        }

        _timer += Time.deltaTime;
        if (_timer > _lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void HitEnemy()
    {
        _enemy?.SetDamage(_damage);
    }
}
