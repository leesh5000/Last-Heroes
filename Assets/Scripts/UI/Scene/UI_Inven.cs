using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_SceneBase
{
    enum GameObjects
    {
        GridPanel,
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);

        // 인벤토리 초기화 시키기
        foreach (Transform child in gridPanel.transform)
            Managers.Resource.Destroy(child.gameObject);

        // 실제 인벤토리 정보를 참고해서
        for (int i=0; i<8; i++)
        {
            GameObject item = Managers.Resource.Instantiate("UI/Scene/UI_Inven_Item");
            item.transform.SetParent(gridPanel.transform);

            UI_Inven_Item invenItem = Util.GetOrAddComponent<UI_Inven_Item>(item);
            invenItem.SetItemInfo($"집행검 {i}번");
        }
    }
}
