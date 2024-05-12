using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionState : GameState
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private RigidBodyMove _rigidbodyMove;
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private ExperienceManager _experienceManager;

    public override void EnterFirstTime()
    {
        base.EnterFirstTime();
        _experienceManager.InitialUpLevel();
        _enemyManager.StartNewWave(0);
    }

    public override void Enter()
    {
        base.Enter();
        _joystick.Activate();
        _rigidbodyMove.enabled = true;
       
    }

    public override void Exit()
    {
        base.Exit();
        _joystick.Deactivate();
        _rigidbodyMove.enabled = false;
    }
}
