using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapController : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        if(player == null)
        {
            Debug.Log("null");
        }
        Managers.inputManagerProperty.MoveActionForTilemap -= TilemapMove;
        Managers.inputManagerProperty.MoveActionForTilemap += TilemapMove;
    }

    void TilemapMove()
    {
        if ((transform.position - player.transform.position).x > 40)
        {
            transform.position -= new Vector3(80, 0, 0);
        }
        else if ((transform.position - player.transform.position).x < -40)
        {
            transform.position += new Vector3(80, 0, 0);
        }
        else if ((transform.position - player.transform.position).y > 40)
        {
            transform.position -= new Vector3(0, 80, 0);
        }
        else if ((transform.position - player.transform.position).y < -40) 
        {
            transform.position += new Vector3(0, 80, 0);
        }
    }    
}
