using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    float rotateSpeed = 800.0f;
    private bool isInsideTrigger = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyBase>().health--;
        }
        isInsideTrigger = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (isInsideTrigger == false)
            {
                isInsideTrigger = true;
                StartCoroutine(StayDamage(collision.gameObject));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInsideTrigger = false;
    }

    
    IEnumerator StayDamage(GameObject enemy)
    {
        while (isInsideTrigger)
        {
            if (enemy != null)
            {
                enemy.gameObject.GetComponent<EnemyBase>().health--;
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                isInsideTrigger = false;
            }
        }
    }

    void YourFunction()
    {
        // 여기에 원하는 기능을 추가하세요.
        Debug.Log("Function called!");
    }
}
