using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinousEffect : Effect
{
    [SerializeField] private float _calldown;
    private float _timer;
    public void ProcessFrame(float frameTime)
    {
        _timer += frameTime;

       
        if (_timer >= _calldown)
        {
            Produce();
            _timer = 0;
        }
    }

    public virtual void Produce()
    {

    }
}
