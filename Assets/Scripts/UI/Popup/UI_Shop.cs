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

        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));

        Button shopExitButton = Get<Button>((int)Buttons.ShopExitButton);
        Image blockerImage = Get<Image>((int)Images.BlockerImage);

        BindUIEvent(shopExitButton.gameObject, ShopExitButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(blockerImage.gameObject, BlockerImageClick, Define.UIEvent.OnPointerClick);

        ShopItemList = Util.FindChildren(gameObject, "ShopItemList", true).transform;

        if (Managers.Game.LobbyShop != null)
        {
            if (Managers.Game.LobbyShop.Items.Count > 0)
            {
                for (int i=0; i<Managers.Game.LobbyShop.Items.Count; i++)
                {
                    Item item = Managers.Game.LobbyShop.Items[i];

                    item.transform.SetParent(ShopItemList.GetChild(i));
                    item.gameObject.transform.localPosition = Vector3.zero;

                    BindUIEvent(item.gameObject, ItemOnBeginDrag, Define.UIEvent.OnBeginDrag);

                }
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
}
