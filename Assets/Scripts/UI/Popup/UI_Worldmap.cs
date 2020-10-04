using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Worldmap : UI_PopupBase
{
    enum GameObjects
    {
        WorldmapExitButton,
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        GameObject worldmapExitButton = Get<GameObject>((int)GameObjects.WorldmapExitButton);
        BindUIEvent(worldmapExitButton, WorldmapExitButtonClick, Define.UIEvent.OnPointerClick);
    }

    void WorldmapExitButtonClick(PointerEventData data)
    {
        if (Managers.Game.WorldmapCamera == null)
        {
            return;
        }

        if (Managers.UI.UI_Worldmap != null)
        {
            Managers.UI.UI_Worldmap.GetComponent<UI_Worldmap>().ClosePopupUI();
        }

        Managers.Game.WorldmapCamera.SetActive(false);
    }
}
