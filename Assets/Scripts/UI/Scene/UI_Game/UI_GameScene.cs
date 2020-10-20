using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GameScene : UI_SceneBase
{
    enum Buttons
    {

    }

    enum Images
    {
        Skill,
        Inven,
    }

    enum GameObjects
    {
        UI_Skill,
        UI_Inven,
    }

    public GameObject UI_Skill { get; set; }
    public GameObject UI_Inven { get; set; }

    public override void Init()
    {
        base.Init();

        if (!Util.IsValid(Managers.UI.UI_GameScene))
            Managers.UI.UI_GameScene = gameObject;

        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));

        UI_Skill = Get<GameObject>((int)GameObjects.UI_Skill);
        UI_Inven = Get<GameObject>((int)GameObjects.UI_Inven);
        UI_Inven.SetActive(false);

        Image skill = Get<Image>((int)Images.Skill);
        Image inven = Get<Image>((int)Images.Inven);

        BindUIEvent(skill.gameObject, SkillImageClick, Define.UIEvent.OnPointerClick);
        BindUIEvent(inven.gameObject, InvenImageClick, Define.UIEvent.OnPointerClick);
    }

    void SkillImageClick(PointerEventData eventData)
    {
        if (!UI_Skill.activeSelf & UI_Inven.activeSelf)
        {
            UI_Skill.SetActive(true);
            UI_Inven.SetActive(false);
        }
    }

    void InvenImageClick(PointerEventData eventData)
    {
        if (UI_Skill.activeSelf & !UI_Inven.activeSelf)
        {
            UI_Skill.SetActive(false);
            UI_Inven.SetActive(true);
        }
    }
}
