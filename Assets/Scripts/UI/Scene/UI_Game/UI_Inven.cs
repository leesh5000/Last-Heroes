using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_SceneBase
{
    enum Transforms
    {
        ItemSlot0,
        ItemSlot1,
        ItemSlot2,
        ItemSlot3,
        ItemSlot4,
        ItemSlot5,
    }

    Transform ItemSlot0;
    Transform ItemSlot1;
    Transform ItemSlot2;
    Transform ItemSlot3;
    Transform ItemSlot4;
    Transform ItemSlot5;

    public List<Item> PlayerItems;

    public override void Init()
    {
        base.Init();

        Managers.UI.UI_Inven = gameObject;

        Managers.UI.UI_GameScene.GetComponent<UI_GameScene>().OnDropItemAction -= OnDropItemEvent;
        Managers.UI.UI_GameScene.GetComponent<UI_GameScene>().OnDropItemAction += OnDropItemEvent;

        Bind<Transform>(typeof(Transforms));
        ItemSlot0 = Get<Transform>((int)Transforms.ItemSlot0);
        ItemSlot1 = Get<Transform>((int)Transforms.ItemSlot1);
        ItemSlot2 = Get<Transform>((int)Transforms.ItemSlot2);
        ItemSlot3 = Get<Transform>((int)Transforms.ItemSlot3);
        ItemSlot4 = Get<Transform>((int)Transforms.ItemSlot4);
        ItemSlot5 = Get<Transform>((int)Transforms.ItemSlot5);

        PlayerItems = new List<Item>();
        Debug.Log($"PlayerItems Count : {PlayerItems.Count}");

        gameObject.SetActive(false);
    }

    void OnDropItemEvent(Item draggedItem)
    {
        if (PlayerItems.Count == 6)
        {
            Debug.Log("Full Inventory");
            return;
        }

        if (Managers.Game.Player.GetComponent<CharacterStat>().Gold < draggedItem.GetComponent<ItemStat>().Gold)
        {
            Debug.Log("lack of Money");
            return;
        }

        Managers.Game.Player.GetComponent<CharacterStat>().Gold -= draggedItem.GetComponent<ItemStat>().Gold;
        Item newItem = Managers.Resource.Instantiate($"Prefabs/Item/{draggedItem.name}").GetComponent<Item>();
        newItem.transform.SetParent(gameObject.transform.GetChild(PlayerItems.Count));
        newItem.GetComponent<RectTransform>().localPosition = Vector3.zero;
        
        PlayerItems.Add(newItem);
    }
}
