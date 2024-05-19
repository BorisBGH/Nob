using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(ArtilleryEffect), menuName = "Effects/ContinuousEffects/" + nameof(ArtilleryEffect))]
public class ArtilleryEffect : ContinousEffect
{
    
    [Space(10)]
    [SerializeField] private ArtilleryShell _artilleryShellPref;
 
    [SerializeField] private float _attackDistance;
    [Range(0, 20f)]
    [SerializeField] private float _distanceToPlayer;
    [SerializeField] int _damage;
    [SerializeField] LayerMask _layerMask;
 // [SerializeField] private Transform _playerTransform;

    
    public override void Produce()
    {
        base.Produce();
        Vector3 constantPos = new Vector3(_player.transform.position.x, 5f, _player.transform.position.z - _distanceToPlayer);
        ArtilleryShell artilleryShell = Instantiate(_artilleryShellPref, constantPos, Quaternion.identity);
        artilleryShell.Setup(_damage, _attackDistance, constantPos, _layerMask, _player);

    }
}
