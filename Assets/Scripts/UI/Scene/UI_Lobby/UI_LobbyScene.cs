using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_LobbyScene : UI_SceneBase
{
    // 로비씬 UI에서 
    enum Buttons
    {
        SelectButton,
        PrevButton,
        NextButton,
    }

    enum Texts
    {
        CharacterNameText,
    }

    Object[] characters;

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

        Text characterNameText = Get<Text>((int)Texts.CharacterNameText);

        characters = Resources.LoadAll("Prefabs/Character");

        Vector3 characterSpawnPos = new Vector3(-61.0f, 0.0f, -13.0f);
        Instantiate(characters[0], characterSpawnPos, Quaternion.Euler(0.0f, -90.0f, 0.0f));
        Managers.Game.PlayerName = characters[0].name;

        Dictionary<string, ContentsData.ChracterStat> statDict = Managers.Data.ChracterStatDict;
        ContentsData.ChracterStat stat = statDict[characters[0].name];

        characterNameText.text = stat.id;
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
