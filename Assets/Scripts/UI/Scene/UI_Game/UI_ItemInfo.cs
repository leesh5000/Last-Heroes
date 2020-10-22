using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ItemInfo : UI_SceneBase
{
    enum Texts
    {
        ItemNameText,
    }

    enum GameObjects
    {
        GridLayer,
    }

    GameObject gridLayer;
    Text itemName;

    List<string> itemStatList;
    public GameObject currentItem { get; set; }

    public override void Init()
    {
        base.Init();

        Managers.UI.UI_ItemInfo = gameObject;

        Bind<GameObject>(typeof(GameObjects));
        Bind<Text>(typeof(Texts));

        gridLayer = Get<GameObject>((int)GameObjects.GridLayer);
        itemName = Get<Text>((int)Texts.ItemNameText);

        GetComponent<Canvas>().overrideSorting = true;
        GetComponent<Canvas>().sortingOrder = 1;

        gameObject.SetActive(false);
    }

    // SetAction(true) 되면 호출되는 함수 OnEnable() // OnDisable()
    public void OpenItemInfo(GameObject go)
    {
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);

        if (currentItem != null)
        {
            if (currentItem.name == go.name)
            {
                ExitItemInfo();
                return;
            }
        }

        currentItem = go;
        itemName.text = go.GetComponent<Item>().ItemStat.Id;
        itemStatList = go.GetComponent<Item>().ItemStat.MakeList();

        for (int i = 0; i < itemStatList.Count; i++)
        {
            if (i > gridLayer.transform.childCount) return;

            Text statText = gridLayer.transform.GetChild(i).GetComponent<Text>();

            if (i == 0)
            {
                switch (itemStatList[i])
                {
                    case "Normal":
                        statText.color = Color.gray;
                        break;

                    case "Rare":
                        statText.color = Color.blue;
                        break;

                    case "Unique":
                        statText.color = Color.magenta;
                        break;

                    case "Legendary":
                        statText.color = Color.red;
                        break;
                }
            }

            statText.text = itemStatList[i];
        }
    }

    public void ExitItemInfo()
    {
        currentItem = null;
        gameObject.SetActive(false);
    }
}
