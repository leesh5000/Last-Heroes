using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Shop : UI_PopupBase
{
    enum Buttons
    {
        ShopExitButton,
    }

    enum Images
    {
        BlockerImage,
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
}
