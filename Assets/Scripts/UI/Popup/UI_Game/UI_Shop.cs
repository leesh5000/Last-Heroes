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
        BlockerImage,
    }

    enum Items
    {
        TinyBoots,
        TinySword,
    }

    public Transform ShopItemList { get; set; }
    List<Item> items = new List<Item>();
    public Image BlockerImage { get; set; }


    public override void Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));
        BlockerImage = Get<Image>((int)Images.BlockerImage);
        BindUIEvent(BlockerImage.gameObject, BlockerImageClick, Define.UIEvent.OnPointerClick);

        Bind<Button>(typeof(Buttons));

        Bind<Item>(typeof(Items));
        Item tinyBoots = Get<Item>((int)Items.TinyBoots);
        Item tinySword = Get<Item>((int)Items.TinySword);
    }

    void BlockerImageClick(PointerEventData eventData)
    {
        if (!Util.IsValid(Managers.UI.UI_Shop))
            return;

        Managers.UI.UI_Shop.gameObject.GetComponent<UI_Shop>().ClosePopupUI();
    }


}
