using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class UI_GameScene : UI_SceneBase
{
    Canvas uI_Joystick;

    GameObject uI_Minimap;
    Canvas uI_MinimapPlusButton;
    Canvas uI_MinimapMinusButton;

    enum Buttons
    {

    }

    public override void Init()
    {
        base.Init();

        uI_Joystick = Util.FindChildren<UI_Joystick>(gameObject).GetComponent<Canvas>();

        uI_Minimap = Util.FindChildren<UI_Minimap>(gameObject).gameObject;

        foreach (Transform child in uI_Minimap.GetComponentsInChildren<Transform>())
        {
            if (child.name == "MinimapPlusButton")
                uI_MinimapPlusButton = child.GetComponent<Canvas>();

            if (child.name == "MinimapMinusButton")
                uI_MinimapMinusButton = child.GetComponent<Canvas>();
        }

        //UI_Right = Util.FindChildren<UI_Right>(gameObject).gameObject;
        //UI_Middle = Util.FindChildren<UI_Middle>(gameObject).gameObject;

        //GameObject resizerCanvas = Util.FindChildren<Canvas>(gameObject).gameObject;

        //UI_Left = Util.FindChildren<UI_Left>(resizerCanvas, null, true).gameObject;
        //UI_Right = Util.FindChildren<UI_Right>(resizerCanvas, null, true).gameObject;
        //UI_Middle = Util.FindChildren<UI_Middle>(resizerCanvas, null, true).gameObject;

        Canvas joystickCanvas = uI_Joystick.GetComponent<Canvas>();

        //Canvas RightCanvas = UI_Right.GetComponent<Canvas>();
        //Canvas MiddleCanvas = UI_Middle.GetComponent<Canvas>();

        uI_Joystick.overrideSorting = true;
        uI_Joystick.sortingOrder = 2;

        uI_MinimapPlusButton.overrideSorting = true;
        uI_MinimapPlusButton.sortingOrder = 2;

        uI_MinimapMinusButton.overrideSorting = true;
        uI_MinimapMinusButton.sortingOrder = 2;


        //RightCanvas.overrideSorting = true;
        //RightCanvas.sortingOrder = 1;

        //MiddleCanvas.overrideSorting = true;
        //MiddleCanvas.sortingOrder = 1;
    }
}
