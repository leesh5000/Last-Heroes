using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_LobbyScene : UI_SceneBase
{
    enum Buttons
    {
        ChracterButton,
        InventoryButton,
        SkillButton,
        CompanionButton,
        BattleButton,

        ShopButton,
        ForgeButton,
        GuildButton,
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        Button characterButton = Get<Button>((int)Buttons.ChracterButton);
        Button inventoryButton = Get<Button>((int)Buttons.InventoryButton);
        Button skillButton = Get<Button>((int)Buttons.SkillButton);
        Button companionButton = Get<Button>((int)Buttons.CompanionButton);
        Button battleButton = Get<Button>((int)Buttons.BattleButton);

        Button shopButton = Get<Button>((int)Buttons.ShopButton);
        Button forgeButton = Get<Button>((int)Buttons.ForgeButton);
        Button guildButton = Get<Button>((int)Buttons.GuildButton);

        BindUIEvent(characterButton.gameObject, ChracterButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(inventoryButton.gameObject, InventoryButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(skillButton.gameObject, SkillButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(companionButton.gameObject, CompanionButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(battleButton.gameObject, BattleButtonClick, Define.UIEvent.OnPointerClick);

        BindUIEvent(shopButton.gameObject, ShopButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(forgeButton.gameObject, ForgeButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(guildButton.gameObject, GuildButtonClick, Define.UIEvent.OnPointerClick);

    }

    void ChracterButtonClick(PointerEventData eventData)
    {

    }

    void InventoryButtonClick(PointerEventData eventData)
    {

    }

    void SkillButtonClick(PointerEventData eventData)
    {

    }

    void CompanionButtonClick(PointerEventData eventData)
    {

    }

    void BattleButtonClick(PointerEventData eventData)
    {
        Managers.Scene.LoadScene(Define.Scene.Game);
    }

    void ShopButtonClick(PointerEventData eventData)
    {

    }

    void ForgeButtonClick(PointerEventData eventData)
    {

    }

    void GuildButtonClick(PointerEventData eventData)
    {

    }
}
