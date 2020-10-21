using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    string _itemName;
    ItemStat _itemStat;

    public ItemStat ItemStat { get { return _itemStat; } }

    Transform _initParent;

    // Start is called before the first frame update
    void Start()
    {
        _itemStat = Util.GetOrAddComponent<ItemStat>(gameObject);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Util.IsValid(Managers.UI.UI_Shop))
        {
            Managers.UI.UI_Shop.GetComponent<UI_Shop>().BlockerImage.gameObject.SetActive(false);
        }

        Managers.UI.DragItem = gameObject;
        _initParent = transform.parent;
        transform.position = eventData.position;
        transform.SetParent(Managers.UI.UI_GameScene.transform.Find("ItemParentPos"));

        GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Util.IsValid(Managers.UI.UI_Shop))
        {
            Managers.UI.UI_Shop.GetComponent<UI_Shop>().BlockerImage.gameObject.SetActive(true);
        }

        Managers.UI.DragItem = null;
        GetComponent<Image>().raycastTarget = true;
        transform.SetParent(_initParent);
        transform.localPosition = Vector3.zero;
    }
}
