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
        OnDrop,
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

        WaveMonster = 8,
        Monster = 9,
        Player = 10,
        Ally = 11,
        Building = 12,
        Wall = 13,

        MinimapWaveMonster = 16,
        MinimapMonster = 17,
        MinimapPlayer = 18,
        MinimapAlly = 19,
        MinimapBuilding = 20,
    }

    public enum WorldObject
    {
        Unknown,
        Chracter,
        Monster,
        NPC,
        Environment,
    }

    public enum Character
    {
        Knight,
    }
}
