using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PopupBase : UI_Base
{
    public override void Init()
    {
        Managers.UI.SetCanvas(gameObject, true);

        // Popup UI는 꼭 풀링이 되도록 만들기
        if (gameObject.GetOrAddComponent<Poolable>() == null)
            gameObject.GetOrAddComponent<Poolable>();
    }

    public virtual void ClosePopupUI()
    {
        Managers.UI.ClosePopupUI(this);
    }
}
