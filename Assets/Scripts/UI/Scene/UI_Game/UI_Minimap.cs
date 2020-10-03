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

    GameObject uI_Worldmap;

    Camera minimapCamera;
    Camera worldmapCamera;

    int minimapCameraZoomMax = 40;
    int minimapCameraZoomMin = 100;


    public override void Init()
    {
        base.Init();

        minimapCamera = GameObject.Find("MinimapCamera").GetComponent<Camera>();
        worldmapCamera = GameObject.Find("WorldmapCamera").GetComponent<Camera>();

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
        if (!Util.IsValid(uI_Worldmap))
        {
            if (worldmapCamera == null)
            {
                worldmapCamera = GameObject.Find("WorldmapCamera").GetComponent<Camera>();
            }

            uI_Worldmap = Managers.UI.OpenPopupUI<UI_Worldmap>().gameObject;
            worldmapCamera.gameObject.SetActive(true);
        }
    }

    void MinimapPlusButtonClick(PointerEventData evnetData)
    {
        if (minimapCamera == null)
            minimapCamera = GameObject.Find("MinimapCamera").GetComponent<Camera>();

        if (minimapCamera.orthographicSize - 20 >= minimapCameraZoomMax)
            minimapCamera.orthographicSize -= 20;
    }

    void MinimapMinusButtonClick(PointerEventData evnetData)
    {
        if (minimapCamera == null)
            minimapCamera = GameObject.Find("MinimapCamera").GetComponent<Camera>();

        if (minimapCamera.orthographicSize + 20 <= minimapCameraZoomMin)
            minimapCamera.orthographicSize += 20;
    }
}
