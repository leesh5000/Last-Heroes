using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GameSceneSubMenu : UI_SceneBase
{
    enum Buttons
    {
        ChracterButton,
        InventoryButton,
        SkillButton,
        CompanionButton,
        OptionButton,
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        Button chracterButton = Get<Button>((int)Buttons.ChracterButton);
        Button inventoryButton = Get<Button>((int)Buttons.InventoryButton);
        Button skillButton = Get<Button>((int)Buttons.SkillButton);
        Button companionButton = Get<Button>((int)Buttons.CompanionButton);
        Button optionButton = Get<Button>((int)Buttons.OptionButton);

        BindUIEvent(inventoryButton.gameObject, InventoryButtonClick, Define.UIEvent.OnPointerClick);
    }

    void InventoryButtonClick(PointerEventData eventData)
    {
        if (!Util.IsValid(Managers.UI.UI_Inventory))
        {
            Managers.UI.UI_Inventory = Managers.UI.OpenPopupUI<UI_Inventory>().gameObject;
        }
    }
}
