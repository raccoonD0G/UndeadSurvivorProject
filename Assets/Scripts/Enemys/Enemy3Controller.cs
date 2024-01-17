using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Controller : EnemyBase
{
    protected override void EnemyMoveToPlayer(float speed)
    {
        base.EnemyMoveToPlayer(speed);
        StartCoroutine(DieAfter10Sec());
    }

    IEnumerator DieAfter10Sec()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            health = 0;
        }
    }

    override protected void Init()
    {
        base.Init();
        ememySpeed = 1.0f;
        health = 10;
    }

    protected override void Start()
    {
        base.Start();
        Init();
    }

    protected override void OnRun()
    {
        base.OnRun();
    }
}
