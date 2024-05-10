using System.Collections;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _creationRadius;
    [SerializeField] private ChapterSettings _chapterSettings;
    private List<Enemy> _enemyList = new List<Enemy>();

    private void Start()
    {
        StartNewWave(0);
    }

    public void StartNewWave(int waveNumber)
    {
        StopAllCoroutines();
        for (int i = 0; i < _chapterSettings.EnemyWavesArray.Length; i++)
        {
            if (_chapterSettings.EnemyWavesArray[i].NumberPerSecond[waveNumber] > 0)
            {
                StartCoroutine(CreateEnemyInSecond(_chapterSettings.EnemyWavesArray[i].Enemy, _chapterSettings.EnemyWavesArray[i].NumberPerSecond[waveNumber]));
            }
        }
    }

    private IEnumerator CreateEnemyInSecond(Enemy enemyPref, float enemiesPerSecon)
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / enemiesPerSecon);
            Create(enemyPref);

        }
    }

    public void Create(Enemy enemyPref)
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        Vector3 position = _playerTransform.position + new Vector3(randomPoint.x, 0, randomPoint.y) * _creationRadius;
        Enemy newEnemy = Instantiate(enemyPref, position, Quaternion.identity);
        newEnemy.Init(_playerTransform);
        _enemyList.Add(newEnemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
    _enemyList.Remove(enemy);
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Handles.color = Color.red;
        Handles.DrawWireDisc(_playerTransform.position, Vector3.up, _creationRadius);
#endif
    }
}
