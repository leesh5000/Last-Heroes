using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Worldmap : UI_PopupBase
{
    Camera worldmapCamera;

    enum GameObjects
    {
        ExitButton,
    }

    public override void Init()
    {
        base.Init();

        worldmapCamera = GameObject.Find("WorldmapCamera").GetComponent<Camera>();

        Bind<GameObject>(typeof(GameObjects));
        GameObject exitButton = Get<GameObject>((int)GameObjects.ExitButton);
        BindUIEvent(exitButton, ExitButtonClick, Define.UIEvent.OnPointerClick);
    }

    void ExitButtonClick(PointerEventData data)
    {
        Managers.UI.ClosePopupUI();

        if (worldmapCamera == null)
        {
            worldmapCamera = GameObject.Find("WorldmapCamera").GetComponent<Camera>();
        }

        worldmapCamera.gameObject.SetActive(false);
    }
}
