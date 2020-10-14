using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_LobbyScene : UI_SceneBase
{
    enum Buttons
    {
        SelectButton,
        PrevButton,
        NextButton,
    }

    enum Texts
    {
        ChracterNameText,
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        Button selectButton = Get<Button>((int)Buttons.SelectButton);
        Button prevButton = Get<Button>((int)Buttons.PrevButton);
        Button nextButton = Get<Button>((int)Buttons.NextButton);

        BindUIEvent(selectButton.gameObject, SelectButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(prevButton.gameObject, PrevButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(nextButton.gameObject, NextButtonClick, Define.UIEvent.OnPointerClick);


        Bind<Text>(typeof(Texts));

        Text characterNameText = Get<Text>((int)Texts.ChracterNameText);



        // TODO : UI_LobbyScene이 생성이 되면, 
    }

    void SelectButtonClick(PointerEventData eventData)
    {
        Managers.Scene.LoadScene(Define.Scene.Game);
    }

    void PrevButtonClick(PointerEventData eventData)
    {
        
    }

    void NextButtonClick(PointerEventData eventData)
    {
        
    }
}
