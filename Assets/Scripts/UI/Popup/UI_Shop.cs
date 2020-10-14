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
        ShopExitButton,
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

        // TODO : (임시) 랜덤으로 아이템 생성 // 나중에는 Shop이 아이템을 가지고 있고, UI_Shop에서는 Shop이 가지고 있는걸 보여주기만 하면 됨
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));

        Button shopExitButton = Get<Button>((int)Buttons.ShopExitButton);
        Image blockerImage = Get<Image>((int)Images.BlockerImage);

        BindUIEvent(shopExitButton.gameObject, ShopExitButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(blockerImage.gameObject, BlockerImageClick, Define.UIEvent.OnPointerClick);

        ShopItemList = Util.FindChildren(gameObject, "ShopItemList", true).transform;

        if (Managers.Game.Shop != null)
        {
            List<Item> items = Managers.Game.Shop.GetComponent<Shop>().Items;

            int count = 0;

            foreach (Item item in items)
            {
                item.transform.SetParent(ShopItemList.GetChild(count++));
                item.gameObject.transform.localPosition = Vector3.zero;

                BindUIEvent(item.gameObject, ItemOnBeginDrag, Define.UIEvent.OnBeginDrag);
                BindUIEvent(item.gameObject, ItemOnDrag, Define.UIEvent.OnBeginDrag);
                BindUIEvent(item.gameObject, ItemOnEndDrag, Define.UIEvent.OnBeginDrag);
            }
        }
    }

    void ShopExitButtonClick(PointerEventData eventData)
    {
        if (!Util.IsValid(Managers.UI.UI_Shop))
            return;

        Managers.UI.UI_Shop.gameObject.GetComponent<UI_Shop>().ClosePopupUI();
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
