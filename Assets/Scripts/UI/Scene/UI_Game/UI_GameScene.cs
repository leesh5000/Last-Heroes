using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GameScene : UI_SceneBase
{
    enum Buttons
    {
        PrevButton,
        NextButton,
        OpenMapButton,
        OpenQuestButton,
    }

    enum Images
    {
        Skill,
        Inven,
    }

    enum GameObjects
    {
        UI_ItemInfo,
        UI_Minimap,
    }

    public Item[] PlayerItems { get; set; } = new Item[6];

    public override void Init()
    {
        base.Init();
        if (!Util.IsValid(Managers.UI.UI_GameScene))
            Managers.UI.UI_GameScene = gameObject;

        Bind<Button>(typeof(Buttons));
        Button prevButton = Get<Button>((int)Buttons.PrevButton);
        Button nextButton = Get<Button>((int)Buttons.NextButton);
        Button openMapButton = Get<Button>((int)Buttons.OpenMapButton);
        Button openQuestButton = Get<Button>((int)Buttons.OpenQuestButton);
        BindUIEvent(prevButton.gameObject, PrevNextButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(nextButton.gameObject, PrevNextButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(openMapButton.gameObject, MapButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(prevButton.gameObject, PrevNextButtonClick, Define.UIEvent.OnBeginDrag);
        BindUIEvent(nextButton.gameObject, PrevNextButtonClick, Define.UIEvent.OnBeginDrag);
        BindUIEvent(openMapButton.gameObject, MapButtonClick, Define.UIEvent.OnBeginDrag);

        Bind<GameObject>(typeof(GameObjects));
        Managers.UI.UI_ItemInfo = Get<GameObject>((int)GameObjects.UI_ItemInfo);
        Managers.UI.UI_Minimap = Get<GameObject>((int)GameObjects.UI_Minimap);

    }

    // 맵이 켜져있으면 끄고, 꺼져있으면 키기
    void MapButtonClick(PointerEventData eventData)
    {
        if (Managers.UI.UI_Minimap == null)
            return;

        if (Managers.UI.UI_Minimap.activeSelf)
        {
            Managers.UI.CloseAllPopupUI();
            Managers.UI.UI_Minimap.SetActive(false);
        }

        else
        {
            Managers.UI.CloseAllPopupUI();
            Managers.UI.UI_Minimap.SetActive(true);
        }
    }

    void PrevNextButtonClick(PointerEventData eventData)
    {
        if (Managers.UI.UI_ItemInfo != null)
            Managers.UI.UI_ItemInfo.GetComponent<UI_ItemInfo>().ExitItemInfo();

        if (Managers.UI.UI_Skill.activeSelf & !Managers.UI.UI_Inven.activeSelf)
        {
            Managers.UI.UI_Skill.SetActive(false);
            Managers.UI.UI_Inven.SetActive(true);
            return;
        }

        if (!Managers.UI.UI_Skill.activeSelf & Managers.UI.UI_Inven.activeSelf)
        {
            Managers.UI.UI_Skill.SetActive(true);
            Managers.UI.UI_Inven.SetActive(false);
            return;
        }
    }
}
