using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum State
    {
        Idle,
        Moving,
        Wait,
        Attack,
    }

    public enum KeyboardEvent
    {
        Forward,
        Left,
        Right,
        Backward,
        None,
    }

    public enum MouseEvent
    {
        OnPressed,
        ButtonDown,
        ButtonUp,
        None,
    }

    public enum CameraMode
    {
        Default,
        Orthographic,
        Perspective,
    }

    public enum UIEvent
    {
        OnPointerDown,
        OnPointerUp,
        OnPointerClick,
        OnBeginDrag,
        OnDrag,
        OnEndDrag,
    }

    public enum Scene
    {
        Default,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    {
        None,
        Bgm,
        Effect,
        MaxCount,
    }

    public enum Layer
    {
        Default = 0,
        Obstacle = 8,

        Monster = 10,
        Player = 11,
        Shop = 12,
        Tent = 13,
        Statue = 14,
        Wall = 15,
            
        MinimapMonster = 17,
        MinimapPlayer = 18,
        MinimapShop = 19,
        MinimapTent = 20,
        MinimapStatue = 21,
    }

    public enum WorldObject
    {
        Unknown,
        Chracter,
        Monster,
        WaveMonster,
        NPC,
        Environment,
    }
}
