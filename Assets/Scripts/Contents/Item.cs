using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerDownHandler
{
    string _itemName;
    ItemStat _itemStat;

    public ItemStat ItemStat { get { return _itemStat; } }
    public Canvas ItemCanvas { get; set; }
    public Image ItemImage { get; set; }

    Transform _initParent;

    void Start()
    {
        _itemStat = Util.GetOrAddComponent<ItemStat>(gameObject);
        ItemCanvas = GetComponent<Canvas>();
        ItemImage = GetComponent<Image>();

    }

    // 아이템 드래그가 시작되면 아이템 정보창 열어주기
    public void OnBeginDrag(PointerEventData eventData)
    {
        // 아이템 정보창 열어주기
        Managers.UI.UI_ItemInfo.GetComponent<UI_ItemInfo>().OpenItemInfo(gameObject);

        GetComponent<Image>().raycastTarget = false;
        Managers.UI.DragItem = gameObject;

        ItemCanvas.overrideSorting = true;
        ItemCanvas.sortingOrder = 20;

        transform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = eventData.position;
    }
    
    // OnEndDrag 보다 OnDrop가 먼저 호출된다!
    // 아이템 드래그가 끝나면 아이템 정보창 닫아주기
    public void OnEndDrag(PointerEventData eventData)
    {
        if (Util.IsValid(Managers.UI.UI_ItemInfo))
        {
            Managers.UI.UI_ItemInfo.GetComponent<UI_ItemInfo>().ExitItemInfo();
        }

        ItemImage.raycastTarget = true;
        ItemCanvas.sortingOrder = 0;
        ItemCanvas.overrideSorting = false;

        Managers.UI.DragItem = null;

        transform.localPosition = Vector3.zero;
    }

    // execution order is OnPointerDown -> OnPointerUp -> OnPointerClick.
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Managers.UI.UI_ItemInfo == null)
            return;

        Managers.UI.UI_ItemInfo.GetComponent<UI_ItemInfo>().OpenItemInfo(gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
