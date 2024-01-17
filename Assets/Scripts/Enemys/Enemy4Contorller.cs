using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Controller : EnemyBase
{
   
    Vector3 passThroughVector;
    Vector3 startPosition;

    protected override void EnemyMoveToPlayer(float speed)
    {
        base.EnemyMoveToPlayer(speed);
    }


    override protected void Init()
    {
        base.Init();
        ememySpeed = 9.0f;
        health = 3;
    }

    protected override void Start()
    {
        base.Start();
        Init();
    }

    override protected void OnRun()
    {
        base.OnRun();
    }

    protected override void Update()
    {
        base.Update();
    }
}
