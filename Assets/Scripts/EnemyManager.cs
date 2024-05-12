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
        newEnemy.Init(_playerTransform, this);
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

    public List<Enemy> GetNearest(Vector3 fromPoint, int numberOfEnemies)
    {
        int returnNumber = Mathf.Min(numberOfEnemies, _enemyList.Count);
        List<Enemy> nearestEnemies = new List<Enemy>(returnNumber);
        bool isAdded = false;

        for (int i = 0; i < returnNumber; i++)
        {
            Enemy nearest = _enemyList[0];
          
            nearestEnemies.Add(nearest);
            nearest.GetComponentInChildren<Renderer>().material.color = Color.blue;
            foreach (Enemy enemy in _enemyList)
            {
                if (Vector3.Distance(fromPoint, enemy.transform.position) < Vector3.Distance(fromPoint, nearest.transform.position) && !isAdded)
                {

                    nearestEnemies.Add(enemy);
                    isAdded = true;
                    enemy.GetComponentInChildren<Renderer>().material.color = Color.green;
                }
                else
                {
                    nearestEnemies.Remove(enemy);
                    enemy.GetComponentInChildren<Renderer>().material.color = Color.black;
                    isAdded = false;
                }


            }
        }
        return nearestEnemies;
    }
}
