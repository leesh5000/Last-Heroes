using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_LoginScene : UI_SceneBase
{
    enum Buttons
    {
        StartButton,
        //ExitButton,
        //OptionButton,
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        Button startButton = Get<Button>((int)Buttons.StartButton);
        //Button optionButton = Get<Button>((int)Buttons.OptionButton);
        //Button exitButton = Get<Button>((int)Buttons.ExitButton);

        BindUIEvent(startButton.gameObject, StartButtonClick, Define.UIEvent.OnPointerClick);
        //BindUIEvent(optionButton.gameObject, OptionButtonClick, Define.UIEvent.OnPointerClick);
        //BindUIEvent(exitButton.gameObject, ExitButtonClick, Define.UIEvent.OnPointerClick);
    }

    void StartButtonClick(PointerEventData data)
    {
        // TODO : GameScene으로 바꿀 것
        Managers.Scene.LoadScene(Define.Scene.Lobby);
    }

    void OptionButtonClick(PointerEventData data)
    {
        //// "||" 둘 중 하나라도 참이면 실행 (둘 다 참이어도 실행)
        //if (ui_Option == null || !ui_Option.IsOn)
        //{
        //    ui_Option = Managers.UI.OpenPopupUI<UI_Option>();
        //    ui_Option.IsOn = true;
        //}
    }

    void ExitButtonClick(PointerEventData data)
    {

    }
}
