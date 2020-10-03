using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Worldmap : UI_PopupBase
{
    enum GameObjects
    {
        ExitButton,
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        GameObject exitButton = Get<GameObject>((int)GameObjects.ExitButton);
        BindUIEvent(exitButton, ExitButtonClick, Define.UIEvent.OnPointerClick);
    }

    void ExitButtonClick(PointerEventData data)
    {
        Managers.UI.ClosePopupUI();

        if (Managers.Game.WorldmapCamera == null)
        {
            return;
        }

        Managers.Game.WorldmapCamera.SetActive(false);
    }
}
