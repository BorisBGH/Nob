using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(ShadowMissilesEffect), menuName = "Effects/ContinuousEffects/" + nameof(ShadowMissilesEffect))]
public class ShadowMissilesEffect : ContinousEffect
{
    [Space(10)]
    [SerializeField] private ShadowMissile _shadowMissilePref;
    [SerializeField] private float _missileSpeed;
    [SerializeField] private int _numberOfBullets;
    [SerializeField] private float _degree;
    [SerializeField] private int _damage = 20;
    [SerializeField] private int _passCount = 2;
   


    public override void Produce()
    {
        base.Produce();
       
        for (int i = 0; i < _numberOfBullets; i++)
        {
            float angle = _degree / _numberOfBullets * i;
            Vector3 direction = Quaternion.Euler(0, angle, 0) * _player.transform.forward;
            ShadowMissile newMissile = Instantiate(_shadowMissilePref, _player.transform.position, Quaternion.identity);
            newMissile.Setup(direction * _missileSpeed, _damage, _passCount);
        }

    }

}
