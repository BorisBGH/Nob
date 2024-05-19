using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public string Name;
    [TextArea(1,3)]
    public string Description;
    public Sprite Sprite;
    public int Level = 0;

    protected EffectsManager _effectsManager;
    protected Player _player;
    protected EnemyManager _enemyManager;

    public virtual void Init(EffectsManager effectsManager, EnemyManager enemyManager, Player player)
    {
        _effectsManager = effectsManager;
        _enemyManager = enemyManager;
        _player = player;

    }

    public virtual void Activate()
    {
        Level++;
    }
}
