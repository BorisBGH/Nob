using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PortalEffect), menuName = "Effects/ContinuousEffects/" + nameof(PortalEffect))]
public class PortalEffect : ContinousEffect
{
    [Space(10)]
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _enemySpeedToPortal;
    [SerializeField] private float _lifeTime;
    [SerializeField] private Portal _portalPref;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] private float _distanceFromPlayer;

    public override void Produce()
    {
        base.Produce();
        float xPos = _player.transform.position.x + Random.Range(-_distanceFromPlayer, _distanceFromPlayer);
        float zPos = _player.transform.position.z + Random.Range(-_distanceFromPlayer, _distanceFromPlayer);
        Vector3 position =  new Vector3(xPos, 0, zPos);
        Portal newPortal = Instantiate(_portalPref, position, Quaternion.identity);
        newPortal.Setup(_speed, _attackDistance, _enemySpeedToPortal, _lifeTime, _damage, _layerMask);
        
    }
}
