using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Minimap : UI_SceneBase
{
    enum GameObjects
    {
        MinimapImage,
        MinimapPlusButton,
        MinimapMinusButton,
    }

    int minimapCameraZoomMax = 40;
    int minimapCameraZoomMin = 100;

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject minimapImage = Get<GameObject>((int)GameObjects.MinimapImage);
        GameObject minimapPlusButton = Get<GameObject>((int)GameObjects.MinimapPlusButton);
        GameObject minimapMinusButton = Get<GameObject>((int)GameObjects.MinimapMinusButton);

        BindUIEvent(minimapImage, MinimapImageClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(minimapPlusButton, MinimapPlusButtonClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(minimapMinusButton, MinimapMinusButtonClick, Define.UIEvent.OnPointerClick);
    }

    void MinimapImageClick(PointerEventData evnetData)
    {
        if (!Util.IsValid(Managers.Game.Ui_Worldmap))
        {
            if (Managers.Game.WorldmapCamera == null)
            {
                return;
            }

            Managers.Game.Ui_Worldmap = Managers.UI.OpenPopupUI<UI_Worldmap>().gameObject;
            Managers.Game.WorldmapCamera.SetActive(true);
        }
    }

    void MinimapPlusButtonClick(PointerEventData evnetData)
    {
        if (Managers.Game.MinimapCamera == null)
            Managers.Game.MinimapCamera = GameObject.Find("MinimapCamera");

        if (Managers.Game.MinimapCamera.GetOrAddComponent<Camera>().orthographicSize - 20 >= minimapCameraZoomMax)
            Managers.Game.MinimapCamera.GetOrAddComponent<Camera>().orthographicSize -= 20;
    }

    void MinimapMinusButtonClick(PointerEventData evnetData)
    {
        if (Managers.Game.MinimapCamera == null)
            Managers.Game.MinimapCamera = GameObject.Find("MinimapCamera");

        if (Managers.Game.MinimapCamera.GetOrAddComponent<Camera>().orthographicSize + 20 <= minimapCameraZoomMin)
            Managers.Game.MinimapCamera.GetOrAddComponent<Camera>().orthographicSize += 20;
    }
}
