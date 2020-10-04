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
    
    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        Button shopExitButton = Get<Button>((int)Buttons.ShopExitButton);

        BindUIEvent(shopExitButton.gameObject, ShopExitButtonClick, Define.UIEvent.OnPointerClick);
    }

    void ShopExitButtonClick(PointerEventData eventData)
    {
        if (Managers.UI.UI_Inventory == null)
            return;

        Managers.UI.UI_Inventory.gameObject.GetComponent<UI_Inventory>().ClosePopupUI();
    }
}
