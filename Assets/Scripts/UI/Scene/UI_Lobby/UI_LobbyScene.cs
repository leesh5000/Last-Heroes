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
        STRText,
        AGIText,
        INTText,
    }

    Text characterNameText;
    Text strText;
    Text agiText;
    Text intText;
    
    LobbyScene lobbyScene;
    Dictionary<string, ContentsData.CharacterStat> statDict;

    int currentIndex = 0;
    GameObject lockTarget;

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
        characterNameText = Get<Text>((int)Texts.CharacterNameText);
        strText = Get<Text>((int)Texts.STRText);
        agiText = Get<Text>((int)Texts.AGIText);
        intText = Get<Text>((int)Texts.INTText);

        // UI에 나타낼 캐릭터 데이터를 가져오기, 처음에 나타낼 캐릭터는 첫번째 있는 캐릭터
        lobbyScene = Managers.Scene.CurrentScene as LobbyScene;
        statDict = Managers.Data.CharacterStatDict;

        lobbyScene.characters[currentIndex].SetActive(true);
        lockTarget = lobbyScene.characters[currentIndex];

        characterNameText.text = statDict[lockTarget.name].ID;
        strText.text = $"STR  "+  statDict[lockTarget.name].STR.ToString();
        agiText.text = $"AGI  " + statDict[lockTarget.name].AGI.ToString();
        intText.text = $"INT  " + statDict[lockTarget.name].INT.ToString();
    }

    // Select 버튼을 누르면, 로비씬 상에서 활성화되있는 캐릭터를 찾기
    void SelectButtonClick(PointerEventData eventData)
    {
        if (lockTarget == null) return;

        Managers.Game.PlayerName = lockTarget.name;
        Managers.Scene.LoadScene(Define.Scene.Game);
    }

    // Prev버튼을 눌러주면, 현재 활성화 돼 있는 캐릭터는 비활성화 시키고, 인덱스에서 -1 인 캐릭터를 활성화 시킨 후, 그 캐릭터 정보 띄우기
    void PrevButtonClick(PointerEventData eventData)
    {
        if (currentIndex - 1 < 0) return;

        lobbyScene.characters[currentIndex].SetActive(false);
        currentIndex--;

        lobbyScene.characters[currentIndex].SetActive(true);
        lockTarget = lobbyScene.characters[currentIndex];

        characterNameText.text = statDict[lockTarget.name].ID;
        strText.text = $"STR  " + statDict[lockTarget.name].STR.ToString();
        agiText.text = $"AGI  " + statDict[lockTarget.name].AGI.ToString();
        intText.text = $"INT  " + statDict[lockTarget.name].INT.ToString();
    }

    void NextButtonClick(PointerEventData eventData)
    {
        if (currentIndex + 1 == lobbyScene.characters.Length) return;

        lobbyScene.characters[currentIndex].SetActive(false);
        currentIndex++;

        lobbyScene.characters[currentIndex].SetActive(true);
        lockTarget = lobbyScene.characters[currentIndex];

        characterNameText.text = statDict[lockTarget.name].ID;
        strText.text = $"STR  " + statDict[lockTarget.name].STR.ToString();
        agiText.text = $"AGI  " + statDict[lockTarget.name].AGI.ToString();
        intText.text = $"INT  " + statDict[lockTarget.name].INT.ToString();
    }
}
