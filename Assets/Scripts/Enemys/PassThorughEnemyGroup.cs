using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThorughEnemyGroup : MonoBehaviour
{
    GameObject player;
    Vector3 startPosition;
    Vector3 destVector;
    bool isPassThrough;

    IEnumerator GoneAfter10Sec()
    {
        yield return new WaitForSeconds(10);
        Managers.resourceManagerProperty.Destroy(gameObject);
    }
    void EnemyGroupMoveToPlayer(float speed)
    {
        Vector3 destinationToPlayer = player.transform.position - transform.position;
        if (destinationToPlayer.magnitude > 0.8f) transform.position += destinationToPlayer.normalized * speed * Time.deltaTime;
    }


    void Init()
    {
        player = GameObject.Find("Player");
        startPosition = transform.position;
        isPassThrough = false;
        StartCoroutine(GoneAfter10Sec());
    }
    void Start()
    {
        Init();
    }

    
    // Update is called once per frame
    void Update()
    {
        if ((gameObject.transform.position - player.transform.position).magnitude <= 5.0f)
        {
            isPassThrough = true;
            destVector = (player.transform.position - startPosition) * 20f;
        }
        if (isPassThrough)
        {
            if (destVector.magnitude > 0.8f) transform.position += destVector.normalized * 15f * Time.deltaTime;
        }
        else
        {
            EnemyGroupMoveToPlayer(15.0f);
        }
    }
}
