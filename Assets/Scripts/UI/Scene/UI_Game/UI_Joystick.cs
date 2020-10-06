using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UI_Joystick : UI_SceneBase
{
    enum GameObjects
    {
        LeftBackground,
        Joystick,
    }

    GameObject LeftBackground { get; set; }
    GameObject Joystick { get; set; }

    float Radius { get; set; }
    Vector3 SavePos { get; set; }
    Vector3 InitPos { get; set; }

    public Vector3 DragPos { get; set; }
    public Vector3 JoyDir { get; set; }

    // Start 함수는 UI_Base 에 있음!
    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        LeftBackground = Get<GameObject>((int)GameObjects.LeftBackground);
        Joystick = Get<GameObject>((int)GameObjects.Joystick);

        // UI_Joystick 게임오브젝트에 화면이 터치가 됐을 때, 조이스틱 배경을 이동하는 이벤트를 배경에 연동
        BindUIEvent(gameObject, OnBeginDrag, Define.UIEvent.OnBeginDrag);
        BindUIEvent(gameObject, OnDrag, Define.UIEvent.OnDrag);
        BindUIEvent(gameObject, OnEndDrag, Define.UIEvent.OnEndDrag);

        // 조이스틱 배경의 절반
        Radius = LeftBackground.GetComponent<RectTransform>().sizeDelta.y * 0.4f;
        InitPos = LeftBackground.transform.position;
    }

    // 화면에 터치가 됐을때,
    void OnBeginDrag(PointerEventData data)
    {
        LeftBackground.SetActive(true);

        DragPos = data.position;
        JoyDir = (DragPos - InitPos).normalized;
        float dist = (DragPos - InitPos).magnitude;

        if (dist > Radius)
        {
            LeftBackground.transform.position = data.position;
            SavePos = data.position;
        }
        else
            SavePos = InitPos;
    }

    void OnDrag(PointerEventData data)
    {

        DragPos = data.position;
        JoyDir = (DragPos - SavePos).normalized;
        float dist = (DragPos - SavePos).magnitude;

        if (dist < Radius)
            Joystick.transform.position = SavePos + JoyDir * dist;
        else
            Joystick.transform.position = SavePos + JoyDir * Radius;
    }

    void OnEndDrag(PointerEventData data)
    {
        LeftBackground.SetActive(false);

        LeftBackground.transform.position = InitPos;
        Joystick.transform.position = InitPos;
        JoyDir = Vector3.zero;
    }
}
