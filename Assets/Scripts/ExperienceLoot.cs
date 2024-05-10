using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceLoot : Loot
{
    
    public override void Take(Collector collector)
    {
        base.Take(collector);
        collector.TakeExperience(Value);
    }
}
