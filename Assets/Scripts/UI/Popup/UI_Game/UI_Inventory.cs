using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inventory : UI_PopupBase
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
        if (!Util.IsValid(Managers.UI.UI_Inventory))
            return;

        Managers.UI.UI_Inventory.gameObject.GetComponent<UI_Inventory>().ClosePopupUI();
    }

    void BlockerImageClick(PointerEventData eventData)
    {
        if (!Util.IsValid(Managers.UI.UI_Inventory))
            return;

        Managers.UI.UI_Inventory.gameObject.GetComponent<UI_Inventory>().ClosePopupUI();
    }
}
