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
    }

    enum Images
    {
        Skill,
        Inven,
    }

    enum GameObjects
    {
        UI_ItemInfo,
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
        BindUIEvent(prevButton.gameObject, PrevNextButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(nextButton.gameObject, PrevNextButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(prevButton.gameObject, PrevNextButtonClick, Define.UIEvent.OnBeginDrag);

        Bind<Image>(typeof(Images));
        Image skillOpenImage = Get<Image>((int)Images.Skill);
        Image invenOpenImage = Get<Image>((int)Images.Inven);
        BindUIEvent(skillOpenImage.gameObject, SkillOpenImageClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(invenOpenImage.gameObject, InvenOpenImageClick, Define.UIEvent.OnPointerClick);

        Bind<GameObject>(typeof(GameObjects));
        Managers.UI.UI_ItemInfo = Get<GameObject>((int)GameObjects.UI_ItemInfo);
    }

    void SkillOpenImageClick(PointerEventData eventData)
    {
        if (Managers.UI.UI_Skill == null)
            Debug.Log("null");

        if (!Managers.UI.UI_Skill.activeSelf & Managers.UI.UI_Inven.activeSelf)
        {
            Managers.UI.UI_Skill.SetActive(true);
            Managers.UI.UI_Inven.SetActive(false);
        }
    }

    void InvenOpenImageClick(PointerEventData eventData)
    {
        if (Managers.UI.UI_Skill.activeSelf & !Managers.UI.UI_Inven.activeSelf)
        {
            Managers.UI.UI_Skill.SetActive(false);
            Managers.UI.UI_Inven.SetActive(true);
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
