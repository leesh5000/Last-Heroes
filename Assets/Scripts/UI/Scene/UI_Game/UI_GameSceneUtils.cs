using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GameSceneUtils : UI_SceneBase
{
    enum GameObjects
    {
        BossAttackToggle,
        InventoryToggle,
    }

    enum Texts
    {
        BossAttackText,
        NormalAttackText,
        InventoryText,
        SkillWindowText,
    }

    Text bossAttackText;
    Text normalAttackText;
    Text inventoryText;
    Text skillWindowText;

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        Bind<Text>(typeof(Texts));

        GameObject bossAttackToggle = Get<GameObject>((int)GameObjects.BossAttackToggle);
        GameObject inventoryToggle = Get<GameObject>((int)GameObjects.InventoryToggle);

        bossAttackText = Get<Text>((int)Texts.BossAttackText);
        bossAttackText.gameObject.SetActive(false);
        normalAttackText = Get<Text>((int)Texts.NormalAttackText);
        normalAttackText.gameObject.SetActive(true);
        inventoryText = Get<Text>((int)Texts.InventoryText);
        inventoryText.gameObject.SetActive(false);
        skillWindowText = Get<Text>((int)Texts.SkillWindowText);
        skillWindowText.gameObject.SetActive(true);

        BindUIEvent(bossAttackToggle, BossAttackToggleClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(inventoryToggle, InventoryToggleClick, Define.UIEvent.OnPointerClick);
    }

    void BossAttackToggleClick(PointerEventData eventData)
    {
        if (!bossAttackText.gameObject.activeSelf)
        {
            bossAttackText.gameObject.SetActive(true);
            normalAttackText.gameObject.SetActive(false);
        }

        else
        {
            bossAttackText.gameObject.SetActive(false);
            normalAttackText.gameObject.SetActive(true);
        }
    }

    void InventoryToggleClick(PointerEventData eventData)
    {
        if (!inventoryText.gameObject.activeSelf)
        {
            inventoryText.gameObject.SetActive(true);
            skillWindowText.gameObject.SetActive(false);
        }

        else
        {
            inventoryText.gameObject.SetActive(false);
            skillWindowText.gameObject.SetActive(true);
        }
    }
}
