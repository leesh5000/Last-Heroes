using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SelectGame : UI_PopupBase
{
    enum Buttons
    {
        FirstDataButton,
        SecondDataButton,
        ThirdDataButton,
        ExitButton,
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        Button firstDataButton = Get<Button>((int)Buttons.FirstDataButton);
        Button secondDataButton = Get<Button>((int)Buttons.SecondDataButton);
        Button thirdDataButton = Get<Button>((int)Buttons.ThirdDataButton);
        Button exitButton = Get<Button>((int)Buttons.ExitButton);

        BindUIEvent(firstDataButton.gameObject, FirstDataButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(secondDataButton.gameObject, SecondDataButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(thirdDataButton.gameObject, ThirdDataButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(exitButton.gameObject, ExitButtonClick, Define.UIEvent.OnPointerClick);
    }

    void FirstDataButtonClick(PointerEventData eventData)
    {
        // TODO
        // 이전에 진행한 데이터가 있다면, 삭제할지 물어보기
        // 이전에 진행한 데이터가 없다면, 물어보지 않고 바로 캐릭터 선택으로 가기

        Managers.Scene.LoadScene(Define.Scene.Lobby);
        Managers.Scene.Clear();
    }

    void SecondDataButtonClick(PointerEventData eventData)
    {

    }

    void ThirdDataButtonClick(PointerEventData eventData)
    {

    }

    void ExitButtonClick(PointerEventData eventData)
    {
        ClosePopupUI();
    }
}
