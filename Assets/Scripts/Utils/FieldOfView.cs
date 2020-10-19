using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FieldOfView : MonoBehaviour
{
    public float ViewRadius { get; set; } = 10.0f;
    public float ViewAngle { get; set; } = 360.0f;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    //public List<Transform> visibleTargets = new List<Transform>();
    public Queue<Transform> visibleTargets = new Queue<Transform>();

    private void Start()
    {
        StartCoroutine("FindTargetsWithDelay", 0.1f);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, ViewRadius, targetMask);

        for (int i=0; i<targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToTarget) < ViewAngle / 2)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask))
                {
                    //visibleTargets.Add(target);
                    visibleTargets.Enqueue(target);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleGlobal)
    {
        if (!angleGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
