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
        UI_Skill,
        UI_Inven,
    }

    public Item[] PlayerItems { get; set; } = new Item[6];

    public Action<Item> OnDropItemAction = null;

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
        GameObject ui_inven = Get<GameObject>((int)GameObjects.UI_Inven);
        BindUIEvent(ui_inven, ItemDrop, Define.UIEvent.OnDrop);
        
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

    void ItemDrop(PointerEventData eventData)
    {
        Item draggedItem = Managers.UI.DragItem.GetComponent<Item>();

        Debug.Log($"Parent Name : {draggedItem.transform.parent.name}");

        // TODO : 부모 이름이 ItemParentPos 여서 안 된다.

        if (draggedItem == null)
            return; 
        if (!draggedItem.transform.parent.name.Contains("Shop"))
            return;

        OnDropItemAction.Invoke(draggedItem);
    }
}
