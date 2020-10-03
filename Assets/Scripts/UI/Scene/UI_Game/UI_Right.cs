using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Right : UI_SceneBase
{
    enum Buttons
    {
        AttackButton,
    }

    public bool isPressed = false;

    public override void Init()
    {
        base.Init();

        //Bind<Button>(typeof(Buttons));
        //Button attackButton = Get<Button>((int)Buttons.AttackButton);
        //BindUIEvent(attackButton.gameObject, AttackButtonUp, Define.UIEvent.OnPointerUp);
        //BindUIEvent(attackButton.gameObject, AttackButtonDown, Define.UIEvent.OnPointerDown);
        //BindUIEvent(attackButton.gameObject, AttackButtonClick, Define.UIEvent.OnPointerClick);
    }

    void AttackButtonClick(PointerEventData data)
    {
        Debug.Log("AttackButtonClick!");
    }

    void AttackButtonDown(PointerEventData data)
    {
        isPressed = true;
        Debug.Log("AttackButtonDown!");
    }

    void AttackButtonUp(PointerEventData data)
    {
        isPressed = false;
        Debug.Log("AttackButtonUp!");
    }

}
