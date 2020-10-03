using System.Collections;
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

        //Managers.UI.OpenSceneUI<UI_LoginScene>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Managers.Scene.LoadScene(Define.Scene.Game);
        }
    }

    public override void Clear()
    {
        
    }
}
