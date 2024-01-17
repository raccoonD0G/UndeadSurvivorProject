using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    GameObject player;
    float cameraSpeed = 25.0f;
    Vector3 rightUp = new Vector3(1, 1, 0);
    Vector3 leftDown = new Vector3(0, 0, 0);
    bool cameraMove;

    private void Start()
    {
        player = GameObject.Find("Player");
        cameraMove = false;
    }
    private void LateUpdate()
    {
        Vector3 worldRightUpPoint = Camera.main.ViewportToWorldPoint(rightUp);
        Vector3 worldLeftDownPoint = Camera.main.ViewportToWorldPoint(leftDown);


        if ((worldRightUpPoint.x - player.transform.position.x) < 1.0f)
        {
            cameraMove = true;
        }
        if ((worldLeftDownPoint.x - player.transform.position.x) > -1.0f)
        {
            cameraMove = true;
        }
        if ((worldRightUpPoint.y - player.transform.position.y) < 1.0f)
        {
            cameraMove = true;
        }
        if ((worldLeftDownPoint.y - player.transform.position.y) > -1.0f)
        {
            cameraMove = true;
        }
        if (cameraMove)
        {
            transform.position -= (transform.position - player.transform.position).normalized * cameraSpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            if ((transform.position - player.transform.position).magnitude < 10.1f) cameraMove = false;
        }
    }
}
