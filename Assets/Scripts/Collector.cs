using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [Range(1,5)]
    [SerializeField] private float _distanceToCollect;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ExperienceManager _experienceManager;

    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _distanceToCollect, _layerMask, QueryTriggerInteraction.Ignore);
        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<Loot>() is Loot loot)
            {
                loot.Collect(this);
            }
        }
    }

    public void TakeExperience(int value)
    {
        _experienceManager.AddExperience(value);
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, Vector3.up, _distanceToCollect);
    }
}
