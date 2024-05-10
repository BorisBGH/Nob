using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] protected int Value;

    public void Collect(Collector collector)
    {
        _collider.enabled = false;
        StartCoroutine(MoveToCollector(collector));
    }

    private IEnumerator MoveToCollector(Collector collector)
    {
        Vector3 a = transform.position;
        Vector3 b = a + Vector3.up * 3f;
        for (float t = 0; t < 1; t += Time.deltaTime / 0.3f)
        {
            Vector3 d = collector.transform.position;
            Vector3 c = d + Vector3.up * 3f;
            Vector3 positionBezier = Bezier.GetPoint(a, b, c, d, t);
            transform.position = positionBezier;
            yield return null;
        }
        Take(collector);

    }

    public virtual void Take(Collector collector)
    {
        Destroy(gameObject);
    }
}
