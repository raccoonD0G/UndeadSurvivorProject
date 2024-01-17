using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScanner : MonoBehaviour
{
    float scanRange;
    LayerMask targetLayer;
    RaycastHit2D[] targets;
    public GameObject nearestTarget;

    private float timer = 0f;
    private float delay = 1f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector3.zero, 0, targetLayer);
            nearestTarget = GetNearestTarget();
            timer = 0f;
        }
        else
        {
            if (nearestTarget != null && nearestTarget.GetComponent<EnemyBase>().health <= 0)
            {
                nearestTarget = GetNearestTarget();
                timer = 0f;
            }
        }
        
    }

    void Init()
    {
        scanRange = 20f;
        targetLayer = 1 << LayerMask.NameToLayer("Enemy");

    }

    private void Start()
    {
        Init();
    }

    GameObject GetNearestTarget()
    {
        GameObject min = null;
        float minDis = scanRange + 1;
        float disBuffer;

        foreach (RaycastHit2D target in targets)
        {
            if (target.transform != null)
            {
                if ((disBuffer = Vector3.Distance(target.transform.position, transform.position)) < minDis)
                {
                    min = target.transform.gameObject;
                    minDis = disBuffer;
                }
            }
        }
        return min;
    }
}
