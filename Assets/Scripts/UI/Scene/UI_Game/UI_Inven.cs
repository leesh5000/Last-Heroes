using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Inven : UI_SceneBase, IDropHandler
{
    enum Transforms
    {
        InvenSlot0,
        InvenSlot1,
        InvenSlot2,
        InvenSlot3,
        InvenSlot4,
        InvenSlot5,
    }

    Transform invenSlot0;
    Transform invenSlot1;
    Transform invenSlot2;
    Transform invenSlot3;
    Transform invenSlot4;
    Transform invenSlot5;

    public List<Item> PlayerItems;

    public override void Init()
    {
        base.Init();

        Managers.UI.UI_Inven = gameObject;

        Bind<Transform>(typeof(Transforms));
        invenSlot0 = Get<Transform>((int)Transforms.InvenSlot0);
        invenSlot1 = Get<Transform>((int)Transforms.InvenSlot1);
        invenSlot2 = Get<Transform>((int)Transforms.InvenSlot2);
        invenSlot3 = Get<Transform>((int)Transforms.InvenSlot3);
        invenSlot4 = Get<Transform>((int)Transforms.InvenSlot4);
        invenSlot5 = Get<Transform>((int)Transforms.InvenSlot5);

        PlayerItems = new List<Item>();

        gameObject.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (Managers.UI.DragItem == null) return;

        if (Managers.UI.DragItem.transform.parent.name.Contains("Shop"))
        {
            Item draggedItem = Managers.UI.DragItem.GetComponent<Item>();
            OnDropItemBuyEvent(draggedItem);
        }

        if (Managers.UI.DragItem.transform.parent.name.Contains("Inven"))
        {
            Item draggedItem = Managers.UI.DragItem.GetComponent<Item>();

            GameObject go = eventData.pointerCurrentRaycast.gameObject;

            // OnDrop 이벤트가 발생한 곳에 아이템이 있다면, 서로 위치 바꿔주기
            if (go.transform.parent.name.Contains("InvenSlot"))
            {
                Transform draggedItemParent = draggedItem.transform.parent;
                Transform goParent = go.transform.parent;

                draggedItem.transform.SetParent(goParent);
                go.transform.SetParent(draggedItemParent);

                RectTransform draggedItemTransform = draggedItem.GetComponent<RectTransform>();
                draggedItemTransform.localPosition = Vector2.zero;

                RectTransform goTransform = go.GetComponent<RectTransform>();
                goTransform.localPosition = Vector2.zero;

                return;
            }

            // OnDrop 이벤트가 발생한 곳이 빈 슬롯 이라면, 빈 슬롯에 아이템 넣어주기
            if (go.transform.parent.name == "UI_Inven")
            {
                draggedItem.transform.SetParent(go.transform);
                return;
            }
        }
    }

    // 아이템을 살 때는 빈 곳 부터 채우기
    public void OnDropItemBuyEvent(Item draggedItem)
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

        foreach (Transform child in transform.GetComponentInChildren<Transform>())
        {
            if (child.childCount == 0)
            {
                newItem.transform.SetParent(child);
                break;
            }

            else
            {
                continue;
            }
        }

        RectTransform rectTransform = newItem.GetComponent<RectTransform>();
        rectTransform.localPosition = Vector2.zero;
        rectTransform.localScale = Vector3.one;

        PlayerItems.Add(newItem);
    }

    public void OnDropItemSellEvent(Item draggedItem)
    {
        if (PlayerItems.Count == 0) return;

        // TODO : 골드 최대치 검사하는 코드 넣기

        Managers.Game.Player.GetComponent<CharacterStat>().Gold += draggedItem.GetComponent<ItemStat>().Gold;
        PlayerItems.Remove(draggedItem);

        // 아이템을 팔 때는 아이템이 사라지는 것이니까 특별히 아래와 같은 코드를 넣어줄 것
        draggedItem.ItemImage.raycastTarget = true;
        draggedItem.ItemCanvas.sortingOrder = 0;
        draggedItem.ItemCanvas.overrideSorting = false;

        Managers.Resource.Destroy(draggedItem.gameObject);
    }
    // TODO ; 팔 때는 정렬하지말고, 살때는 빈 곳 부터 채우기
}
