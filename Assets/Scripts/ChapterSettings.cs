using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct EnemyWave
{
    public Enemy Enemy;
    public float[] NumberPerSecond;
}

[CreateAssetMenu]
public class ChapterSettings : ScriptableObject
{
    public EnemyWave[] EnemyWavesArray;
}
