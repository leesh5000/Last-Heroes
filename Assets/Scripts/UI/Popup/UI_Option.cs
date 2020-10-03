using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Option : UI_PopupBase
{
    public bool IsOn { get; set; } = false;

    enum Buttons
    {
        ExitButton,
    }

    void Start()
    {
        Init();    
    }

    public override void Init()
    {
        base.Init();


        Bind<Button>(typeof(Buttons));
        Button exitButton = Get<Button>((int)Buttons.ExitButton);
        BindUIEvent(exitButton.gameObject, ExitButtonClick, Define.UIEvent.OnPointerClick);
    }

    void ExitButtonClick(PointerEventData data)
    {
        Managers.UI.ClosePopupUI();
        IsOn = false;
    }
}
