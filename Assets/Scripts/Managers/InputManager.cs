using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{

    public Action MoveActionForPlayer = null;
    public Action MoveActionForTilemap = null;
    public Action SkillActionForPlayer = null;
    public Action<GameObject> ClickMonsterAction = null;

    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q) && SkillActionForPlayer != null) SkillActionForPlayer.Invoke();
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            if (MoveActionForPlayer != null) MoveActionForPlayer.Invoke();
            if (MoveActionForTilemap != null) MoveActionForTilemap.Invoke();
        }
    }
}
