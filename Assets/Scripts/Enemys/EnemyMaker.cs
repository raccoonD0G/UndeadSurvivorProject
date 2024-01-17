using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    GameObject player;
    int enemyCount;
    int timeCount = 0;

    GameObject[] Enemys;

    GameObject passThroughEnemyGroupPrefab;

    void Start()
    {
        player = GameObject.Find("Player");
        enemyCount = 0;

        Enemys = new GameObject[5];

        Enemys[0] = Managers.resourceManagerProperty.Load<GameObject>("Prefabs/Enemy0");
        Enemys[1] = Managers.resourceManagerProperty.Load<GameObject>("Prefabs/Enemy1");
        Enemys[2] = Managers.resourceManagerProperty.Load<GameObject>("Prefabs/Enemy2");
        Enemys[3] = Managers.resourceManagerProperty.Load<GameObject>("Prefabs/Enemy3");
        Enemys[4] = Managers.resourceManagerProperty.Load<GameObject>("Prefabs/Enemy4");
        passThroughEnemyGroupPrefab = Managers.resourceManagerProperty.Load<GameObject>("Prefabs/PassThroughEnemy");

        StartCoroutine(TimeCounter(1.0f));
    }


    IEnumerator TimeCounter(float n)
    {
        while (true)
        {
            timeCount++;
            if (timeCount % 1 == 0)
            {
                Vector3 pos = GetOutOfCameraVector3();
                MakeEnemy(enemyCount, 0, pos);
            }
            if (timeCount % 2 == 0)
            {
                Vector3 pos = GetOutOfCameraVector3();
                MakeEnemy(enemyCount, 1, pos);
            }
            if (timeCount % 3 == 0)
            {
                Vector3 pos = GetOutOfCameraVector3();
                MakeEnemy(enemyCount, 2, pos);
            }
            if (timeCount % 10 == 0)
            {
                Vector3 pos = GetOutOfCameraVector3();
                MakePassThroughEnemy(pos);
            }
            if (timeCount % 25 == 0)
            {
                MakeCircleEnemy();
            }
            yield return new WaitForSeconds(n);

        }
    }

    void MakeCircleEnemy()
    {
        int numberOfObjects = 45;
        float radius = 15f;
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
            newPos += player.transform.position;
            MakeEnemy(enemyCount, 3, newPos);
        }
    }

    void MakePassThroughEnemy(Vector3 position)
    {
        GameObject newPassThroughEnemyGroup;
        newPassThroughEnemyGroup = Object.Instantiate(passThroughEnemyGroupPrefab, gameObject.transform);
        newPassThroughEnemyGroup.transform.position = position;
        Vector3 spawnPosition;
        GameObject tmp;
        for (int i = 0; i < 8; i++)
        {
            spawnPosition = position + new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0);
            tmp = MakeEnemy(enemyCount, 4, spawnPosition);
            tmp.transform.parent = newPassThroughEnemyGroup.transform;
            tmp.GetComponent<EnemyBase>().moveToPlayer = false;
        }
    }

    public GameObject MakeEnemy(int gameObjectNum, int version, Vector3 position)
    {
        GameObject newEnemy;
        switch (version)
        {
            case 0:
                newEnemy = Object.Instantiate(Enemys[0], gameObject.transform);
                break;
            case 1:
                newEnemy = Object.Instantiate(Enemys[1], gameObject.transform);
                break;
            case 2:
                newEnemy = Object.Instantiate(Enemys[2], gameObject.transform);
                break;
            case 3:
                newEnemy = Object.Instantiate(Enemys[3], gameObject.transform);
                break;
            case 4:
                newEnemy = Object.Instantiate(Enemys[4], gameObject.transform);
                break;
            default:
                newEnemy = Object.Instantiate(Enemys[0], gameObject.transform);
                break;
        }
        newEnemy.tag = "Enemy";
        newEnemy.GetComponent<Transform>().position = position;
        enemyCount++;
        return newEnemy;
    }

    Vector3 GetOutOfCameraVector3()
    {
        float x = 0.0f;
        float y = 0.0f;
        int num = (int)(Random.value * 4.0f);
        switch (num)
        {
            case 0:
                x = 1.2f;
                y = Random.value;
                break;
            case 1:
                x = -0.2f;
                y = Random.value;
                break;
            case 2:
                x = Random.value;
                y = 1.2f;
                break;
            case 3:
                x = Random.value;
                y = -0.2f;
                break;
            case 4:
                break;
        }
        Vector3 outOfCameraVector3 = new Vector3(x, y, 0);
        return Camera.main.ViewportToWorldPoint(outOfCameraVector3);
    }
}

