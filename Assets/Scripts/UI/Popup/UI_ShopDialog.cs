using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ShopDialog : UI_PopupBase
{
    enum GameObjects
    {
        ShopOpenButton,
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        GameObject shopOpenButton = Get<GameObject>((int)GameObjects.ShopOpenButton);
        BindUIEvent(shopOpenButton, ShopOpenButtonClick, Define.UIEvent.OnPointerClick);
    }

    void ShopOpenButtonClick(PointerEventData eventData)
    {
        if (!Util.IsValid(Managers.UI.UI_Shop))
        {
            Managers.UI.UI_Shop = Managers.UI.OpenPopupUI<UI_Shop>().gameObject;
        }
    }
}
