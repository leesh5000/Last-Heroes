using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Login : UI_SceneBase
{
    UI_Option ui_Option;

    enum Buttons
    {
        ExitButton,
        PlayButton,
        OptionButton,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        Button playButton = Get<Button>((int)Buttons.PlayButton);
        Button optionButton = Get<Button>((int)Buttons.OptionButton);
        Button exitButton = Get<Button>((int)Buttons.ExitButton);

        BindUIEvent(playButton.gameObject, PlayButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(optionButton.gameObject, OptionButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(exitButton.gameObject, ExitButtonClick, Define.UIEvent.OnPointerClick);

        
    }

    void PlayButtonClick(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.Game);
    }

    void OptionButtonClick(PointerEventData data)
    {
        // "||" 둘 중 하나라도 참이면 실행 (둘 다 참이어도 실행)
        if (ui_Option == null || !ui_Option.IsOn)
        {
            ui_Option = Managers.UI.OpenPopupUI<UI_Option>();
            ui_Option.IsOn = true; 
        }
    }

    void ExitButtonClick(PointerEventData data)
    {

    }
}
