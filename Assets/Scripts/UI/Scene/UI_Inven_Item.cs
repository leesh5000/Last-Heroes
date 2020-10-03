using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inven_Item : UI_Base
{
    enum Images
    {
        ItemIcon,
    }

    enum Texts
    {
        ItemName,
    }

    string _itemName;

    public override void Init()
    {
        Bind<Image>(typeof(Images));
        Bind<Text>(typeof(Texts));

        Get<Text>((int)Images.ItemIcon).GetComponent<Text>().text = _itemName;

        GameObject item = Get<Image>((int)Images.ItemIcon).GetComponent<Image>().gameObject;
        item.BindUIEvent((PointerEventData) => { Debug.Log($"Item Clicked! {_itemName}"); }, Define.UIEvent.OnPointerClick);
    }

    public void SetItemInfo(string name)
    {
        _itemName = name;

        // 이름 말고 다른거 추가되면 더 ++
    }
}
