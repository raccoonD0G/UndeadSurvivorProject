using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defines
{

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }
    public enum UIEvent
    {
        Click,
        Drag
    }
    public enum MouseEvent
    {
        Press,
        Click
    }
    public enum CameraMode
    {
        QuarterView
    }
}
