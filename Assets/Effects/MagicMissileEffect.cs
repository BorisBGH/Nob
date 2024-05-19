using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(MagicMissileEffect), menuName = "Effects/ContinuousEffects/" + nameof(MagicMissileEffect))]
public class MagicMissileEffect : ContinousEffect
{
    [SerializeField] private MagicMissile _magicMissilePref;
    [SerializeField] private float _missileSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private int _numberOfEnemiesToAttack = 4;


    public override void Produce()
    {
        base.Produce();
        _effectsManager.StartCoroutine(EffectProcess());

    }

    [SerializeField] private List<Enemy> nearestEnemies = new List<Enemy>();
    private IEnumerator EffectProcess()
    {
        nearestEnemies = _enemyManager.GetNearest(_player.transform.position, _numberOfEnemiesToAttack);
        if (nearestEnemies.Count > 0)
        {
            foreach (var enemy in nearestEnemies)
            {
                MagicMissile magicMissile = Instantiate(_magicMissilePref, _player.transform.position, Quaternion.identity);
                magicMissile.Setup(enemy, _damage, _missileSpeed);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
