using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Shop : UI_PopupBase
{
    public Transform ShopItemList { get; set; }

    enum Buttons
    {
        
    }

    enum Images
    {
        BlockerImage,
    }

    enum GameObjects
    {

    }

    public override void Init()
    {
        base.Init();

        if (Util.IsValid(Managers.UI.UI_GameScene))
        {
            GameObject UI_Inven = Managers.UI.UI_GameScene.GetComponent<UI_GameScene>().UI_Inven;
            GameObject UI_Skill = Managers.UI.UI_GameScene.GetComponent<UI_GameScene>().UI_Skill;

            if (UI_Skill.activeSelf)
            {
                UI_Skill.SetActive(false);
                UI_Inven.SetActive(true);
            }
        }

        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));

        Image blockerImage = Get<Image>((int)Images.BlockerImage);

        BindUIEvent(blockerImage.gameObject, BlockerImageClick, Define.UIEvent.OnPointerClick);
    }

    void BlockerImageClick(PointerEventData eventData)
    {
        if (!Util.IsValid(Managers.UI.UI_Shop))
            return;

        Managers.UI.UI_Shop.gameObject.GetComponent<UI_Shop>().ClosePopupUI();
    }

    void ItemOnBeginDrag(PointerEventData eventData)
    {

    }

    void ItemOnDrag(PointerEventData eventData)
    {

    }

    void ItemOnEndDrag(PointerEventData eventData)
    {

    }
}
