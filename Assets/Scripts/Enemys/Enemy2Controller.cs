using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : EnemyBase
{
    protected override void EnemyMoveToPlayer(float speed)
    {
        base.EnemyMoveToPlayer(speed);
    }

    override protected void Init()
    {
        base.Init();
        ememySpeed = 5.0f;
        health = 7;
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
