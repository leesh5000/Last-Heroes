using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Skill : UI_SceneBase
{
    public override void Init()
    {
        base.Init();

        Managers.UI.UI_Skill = gameObject;

    }
}
