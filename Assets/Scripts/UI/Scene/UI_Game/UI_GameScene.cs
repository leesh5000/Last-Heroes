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

    //void ItemDrop(PointerEventData eventData)
    //{
    //    if (Managers.UI.DragItem == null) return;

    //    Item draggedItem = Managers.UI.DragItem.GetComponent<Item>();

    //    if (Managers.UI.DragItem != null)
    //        Managers.UI.DragItem = null;

    //    OnDropItemAction.Invoke(draggedItem);
    //}
}
