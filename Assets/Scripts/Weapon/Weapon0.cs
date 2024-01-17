using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon0 : MonoBehaviour
{
    float rotateSpeed = 300f;
    int numberOfBullet0 = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
    }
}
