using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyShop : MonoBehaviour
{
    public List<Item> Items { get; } = new List<Item>();

    void Start()
    {
        if (Managers.Game.LobbyShop == null)
            Managers.Game.LobbyShop = Util.GetOrAddComponent<LobbyShop>(gameObject);

        // TODO : 랜덤으로 아이템 생성
        Item item = Managers.Resource.Instantiate("Prefabs/Item/Sword").GetComponent<Item>();
        Items.Add(item);
    }

    void Update()
    {
        //if (Managers.UI.UI_Shop != null)
        //{
        //    if (_shopItemList == null)
        //        _shopItemList = Managers.UI.UI_Shop.GetComponent<UI_Shop>().ShopItemList;

        //    for (int i=0; i<_items.Count; i++)
        //    {
        //        if (i > _shopItemList.transform.childCount) return;

        //        _items[i].transform.SetParent(_shopItemList.transform.GetChild(i));
        //    }
        //}
    }
}
