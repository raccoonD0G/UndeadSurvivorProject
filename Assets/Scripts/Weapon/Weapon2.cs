using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    EnemyScanner enemyScanner;
    GameObject targetEnemy;
    float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        enemyScanner = GameObject.Find("EnemyScanner").GetComponent<EnemyScanner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyScanner.nearestTarget == null) return;
        targetEnemy = enemyScanner.nearestTarget;
        Vector3 dir = targetEnemy.transform.position - transform.position;
        transform.position += dir * speed * Time.deltaTime;
    }
}
