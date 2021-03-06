﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Login;

        if (Managers.Game.Ui_LoginScene == null)
        {
            Managers.Game.Ui_LoginScene = Managers.UI.OpenSceneUI<UI_LoginScene>().gameObject;
        }
    }

    void Update()
    {

    }

    public override void Clear()
    {
        
    }
}
