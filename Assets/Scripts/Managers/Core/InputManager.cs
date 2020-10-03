using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 인풋매니저는 리스너 패턴
public class InputManager
{
    public Action<Define.KeyboardEvent> KeyboardAction = null;
    public Action<Define.MouseEvent> MouseAction = null;
    public Action JoystickAcition = null;

    // Monobehaviour가 없으니까 OnUpdate
    public void OnUpdate()
    {
        //// UI가 클릭된 상황이라면 바로 리턴하기
        //if (EventSystem.current.IsPointerOverGameObject())
        //    return;

        if (KeyboardAction != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                KeyboardAction.Invoke(Define.KeyboardEvent.Forward);
                Debug.Log("Invoke Define.KeyboardEvent.Forward");
            }

            else if (Input.GetKey(KeyCode.S))
            {
                KeyboardAction.Invoke(Define.KeyboardEvent.Backward);
                Debug.Log("Invoke Define.KeyboardEvent.Backward");
            }

            else if (Input.GetKey(KeyCode.A))
            {
                KeyboardAction.Invoke(Define.KeyboardEvent.Left);
                Debug.Log("Invoke Define.KeyboardEvent.Left");
            }

            else if (Input.GetKey(KeyCode.D))
            {
                KeyboardAction.Invoke(Define.KeyboardEvent.Right);
                Debug.Log("Invoke Define.KeyboardEvent.Right");
            }

            else
            {
                KeyboardAction.Invoke(Define.KeyboardEvent.None);
                Debug.Log("Invoke Define.KeyboardEvent.None");
            }
        }

        if (MouseAction != null)
        {
            // GetMouseButton == 누르고 있는동안 이벤트 발생
            // GetMouseButtonDown == 누를때 한번
            if (Input.GetMouseButton(1))
            {
                Debug.Log("OnPressed");

                MouseAction.Invoke(Define.MouseEvent.OnPressed);
            }

            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("ButtonDown");

                MouseAction.Invoke(Define.MouseEvent.ButtonDown);
            }

            if (Input.GetMouseButtonUp(1))
            {
                Debug.Log("ButtonUp");

                MouseAction.Invoke(Define.MouseEvent.ButtonUp);
            }

            if (!Input.anyKey)
            {
                Debug.Log("!anykey");
                MouseAction.Invoke(Define.MouseEvent.None);
            }
        }

        if (JoystickAcition != null)
            JoystickAcition.Invoke();
    }

    public void Clear()
    {
        KeyboardAction = null;
        MouseAction = null;
        JoystickAcition = null;
    }
}

