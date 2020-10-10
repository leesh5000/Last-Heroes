using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Lobby;

        if (Managers.Game.Ui_LobbyScene == null)
        {
            Managers.Game.Ui_LobbyScene = Managers.UI.OpenSceneUI<UI_LobbyScene>().gameObject;
        }
    }

    void Update()
    {
        
    }

    public override void Clear()
    {
        
    }
}
