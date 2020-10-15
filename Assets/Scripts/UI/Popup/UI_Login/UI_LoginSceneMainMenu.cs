using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_LoginSceneMainMenu : UI_PopupBase
{
    enum Buttons
    {
        NewGameButton,
        ContinueButton,
        SettingButton,
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        Button newGameButton = Get<Button>((int)Buttons.NewGameButton);
        Button continueButton = Get<Button>((int)Buttons.ContinueButton);
        Button settingButton = Get<Button>((int)Buttons.SettingButton);

        BindUIEvent(newGameButton.gameObject, NewGameButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(continueButton.gameObject, ContinueButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(settingButton.gameObject, SettingButtonClick, Define.UIEvent.OnPointerClick);
    }

    void NewGameButtonClick(PointerEventData eventData)
    {
        UI_SelectGame popupUI = Managers.UI.OpenPopupUI<UI_SelectGame>();
        //popupUI.transform.SetParent(gameObject.transform);
        //popupUI.transform.localPosition = Vector3.zero;
    }

    void ContinueButtonClick(PointerEventData eventData)
    {

    }

    void SettingButtonClick(PointerEventData eventData)
    {


    }

    // TODO : 체력바 상단에 ?
}
