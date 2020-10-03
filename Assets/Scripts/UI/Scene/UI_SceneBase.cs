using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SceneBase : UI_Base
{
    public override void Init()
    {
        Managers.UI.SetCanvas(gameObject, false);
    }
}
