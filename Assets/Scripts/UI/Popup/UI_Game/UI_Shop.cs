using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Shop : UI_PopupBase
{
    enum Buttons
    {
        
    }

    enum Images
    {
        BlockerImage1,
        BlockerImage2,
        ItemScrollView,
    }

    enum Items
    {
        TinyBoots,
        TinySword,
    }

    public Transform ShopItemList { get; set; }

    public Image ItemScrollView { get; set; }
    public Image BlockerImage1 { get; set; }
    public Image BlockerImage2 { get; set; }

    public Action<Item> OnDropItemBuyAction = null;
    public Action<Item> OnDropItemSellAction = null;

    public override void Init()
    {
        base.Init();

        Managers.UI.UI_Shop = gameObject;

        if (Managers.UI.UI_Inven != null)
        {
            OnDropItemBuyAction -= Managers.UI.UI_Inven.GetComponent<UI_Inven>().OnDropItemBuyEvent;
            OnDropItemBuyAction += Managers.UI.UI_Inven.GetComponent<UI_Inven>().OnDropItemBuyEvent;
            OnDropItemSellAction -= Managers.UI.UI_Inven.GetComponent<UI_Inven>().OnDropItemSellEvent;
            OnDropItemSellAction += Managers.UI.UI_Inven.GetComponent<UI_Inven>().OnDropItemSellEvent;
        }

        Bind<Image>(typeof(Images));
        BlockerImage1 = Get<Image>((int)Images.BlockerImage1);
        BlockerImage2 = Get<Image>((int)Images.BlockerImage2);
        ItemScrollView = Get<Image>((int)Images.ItemScrollView);

        BindUIEvent(BlockerImage1.gameObject, BlockerImageClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(BlockerImage2.gameObject, BlockerImageClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(BlockerImage1.gameObject, BlockerImageOnBeginDrag, Define.UIEvent.OnBeginDrag);
        BindUIEvent(BlockerImage2.gameObject, BlockerImageOnBeginDrag, Define.UIEvent.OnBeginDrag);
        BindUIEvent(BlockerImage1.gameObject, OnDropItemInBlocker, Define.UIEvent.OnDrop);
        BindUIEvent(BlockerImage2.gameObject, OnDropItemInBlocker, Define.UIEvent.OnDrop);
        BindUIEvent(ItemScrollView.gameObject, OnDropItemInShop, Define.UIEvent.OnDrop);

        Bind<Button>(typeof(Buttons));

        Bind<Item>(typeof(Items));
        Item tinyBoots = Get<Item>((int)Items.TinyBoots);
        Item tinySword = Get<Item>((int)Items.TinySword);
    }

    void BlockerImageClick(PointerEventData eventData)
    {
        if (!Util.IsValid(Managers.UI.UI_Shop))
            return;

        // 상점을 나갈때, 아이템 정보창이 열려있다면 닫아주기
        if (Util.IsValid(Managers.UI.UI_ItemInfo))
        {
            ExitItemInfo();
        }

        Managers.UI.UI_Shop.gameObject.GetComponent<UI_Shop>().ClosePopupUI();
    }

    // 상점이 열려있을때, 블락커를 드래그하면 상점 나가기
    void BlockerImageOnBeginDrag(PointerEventData eventData)
    {
        if (!Util.IsValid(Managers.UI.UI_Shop))
            return;

        // 상점을 나갈때, 아이템 정보창이 열려있다면 닫아주기
        if (Util.IsValid(Managers.UI.UI_ItemInfo))
        {
            ExitItemInfo();
        }

        Managers.UI.UI_Shop.gameObject.GetComponent<UI_Shop>().ClosePopupUI();
    }

    void OnDropItemInBlocker(PointerEventData eventData)
    {
        if (Managers.UI.DragItem == null) return;

        // 아이템의 부모가 Shop이면, 이건 사는거
        if (Managers.UI.DragItem.transform.parent.name.Contains("Shop"))
        {
            Item draggedItem = Managers.UI.DragItem.GetComponent<Item>();

            OnDropItemBuyAction.Invoke(draggedItem);
        }

        // 아이템의 부모가 Inven이면, 이건 파는
        if (Managers.UI.DragItem.transform.parent.name.Contains("Inven"))
        {
            Item draggedItem = Managers.UI.DragItem.GetComponent<Item>();

            ExitDragItemInfo(draggedItem);

            OnDropItemSellAction.Invoke(draggedItem);
        }
    }

    // TODO : 아이템을 인벤에서 상점으로 끌어서 파는 경우도 구현할 것
    void OnDropItemInShop(PointerEventData eventData)
    {
        if (Managers.UI.DragItem == null) return;

        if (Managers.UI.DragItem.transform.parent.name.Contains("Inven"))
        {
            Item draggedItem = Managers.UI.DragItem.GetComponent<Item>();

            ExitDragItemInfo(draggedItem);

            OnDropItemSellAction.Invoke(draggedItem);
        }
    }

    // 인벤 창에서 아이템 2의 아이템 정보창을 열어놓고, 아이템 1을 팔았을 때는 아이템 2의 정보 창을 닫을필요 없다.
    // 하지만, 아이템 2의 정보창을 열어놓고 아이템 2를 팔았을 경우에는 아이템 2의 정보창을 닫아야하니까 이 함수를 이용한다.
    void ExitDragItemInfo(Item draggedItem)
    {
        if (Util.IsValid(Managers.UI.UI_ItemInfo))
        {
            if (Managers.UI.UI_ItemInfo.GetComponent<UI_ItemInfo>().currentItem == draggedItem.gameObject)
            {
                Managers.UI.UI_ItemInfo.GetComponent<UI_ItemInfo>().ExitItemInfo();
            }
        }
    }

    // 무조건 아이템 정보창을 닫는 함
    void ExitItemInfo()
    {
        if (Util.IsValid(Managers.UI.UI_ItemInfo))
        {
            Managers.UI.UI_ItemInfo.GetComponent<UI_ItemInfo>().ExitItemInfo();
        }
    }
}
