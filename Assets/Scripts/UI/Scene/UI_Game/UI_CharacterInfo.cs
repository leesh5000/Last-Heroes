using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CharacterInfo : UI_SceneBase
{
    enum Sliders
    {
        XpBarSlider,
        HpBarSlider,
        MpBarSlider,
    }

    enum Texts
    {
        CharacterNameText,
        CharacterSubNameText,
        HPText,
        MPText,
        ATKText,
        DEFText,
        SPDText,
        STRText,
        AGIText,
        INTText,
        GoldText,
    }

    enum Buttons
    {
        StatButton,
        ATKButton,
        DEFButton,
        SPDButton,
        STRButton,
        AGIButton,
        INTButton,
    }

    enum Images
    {
        CharacterStatImage,

    }

    CharacterStat characterStat;
    Slider xpBarSlider;
    Slider hpBarSlider;
    Slider mpBarSlider;

    Text hpText;
    Text mpText;
    Text strText;
    Text agiText;
    Text intText;
    Text atkText;
    Text defText;
    Text spdText;
    Text goldText;

    Button statButton;
    Image characterStatImage;

    public override void Init()
    {
        base.Init();

        if (characterStat == null)
            characterStat = Managers.Game.Player.GetComponent<PlayerController>().Stat;

        Bind<Slider>(typeof(Sliders));

        xpBarSlider = Get<Slider>((int)Sliders.XpBarSlider);
        hpBarSlider = Get<Slider>((int)Sliders.HpBarSlider);
        mpBarSlider = Get<Slider>((int)Sliders.MpBarSlider);

        Bind<Text>(typeof(Texts));

        Text characterNameText = Get<Text>((int)Texts.CharacterNameText);
        characterNameText.text = characterStat.Id;

        Text characterSubNameText = Get<Text>((int)Texts.CharacterSubNameText);
        characterSubNameText.text = $"Lv{characterStat.Level}  " + characterStat.SubName;

        hpText = Get<Text>((int)Texts.HPText);
        mpText = Get<Text>((int)Texts.MPText);
        strText = Get<Text>((int)Texts.STRText);
        agiText = Get<Text>((int)Texts.AGIText);
        intText = Get<Text>((int)Texts.INTText);
        atkText = Get<Text>((int)Texts.ATKText);
        defText = Get<Text>((int)Texts.DEFText);
        spdText = Get<Text>((int)Texts.SPDText);
        goldText = Get<Text>((int)Texts.GoldText);

        Dictionary<string, ContentsData.ChracterStat> statDict = Managers.Data.ChracterStatDict;
        ContentsData.ChracterStat stat = statDict[Managers.Game.Player.name];
        //characterSubNameText.text = stat.description;

        Bind<Button>(typeof(Buttons));
        statButton = Get<Button>((int)Buttons.StatButton);
        BindUIEvent(statButton.gameObject, StatButtonClick, Define.UIEvent.OnPointerClick);

        Bind<Image>(typeof(Images));
        characterStatImage = Get<Image>((int)Images.CharacterStatImage);
        characterStatImage.gameObject.SetActive(false);
    }

    // 시시각각 변하는 캐릭터 스텟을 나타내야하므로 Update문으로 사용할 것
    public void Update()
    {
        xpBarSlider.value = characterStat.CurrentExp / (float)characterStat.Exp;
        hpBarSlider.value = characterStat.Hp / (float)characterStat.MaxHp;
        mpBarSlider.value = characterStat.Mp/ (float)characterStat.MaxMp;

        hpText.text = characterStat.Hp.ToString();
        mpText.text = characterStat.Mp.ToString();
        strText.text = characterStat.STR.ToString();
        agiText.text = characterStat.AGI.ToString();
        intText.text = characterStat.INT.ToString();

        goldText.text = characterStat.Gold.ToString();

        int attack = characterStat.Attack + characterStat.STR;
        int defense = characterStat.Defense + characterStat.AGI;
        float attackSpeed = characterStat.AttackSpeed + (float)(characterStat.AGI * 0.01);
        float moveSpeed = characterStat.MoveSpeed + (float)(characterStat.AGI * 0.01);

        atkText.text = attack.ToString();
        defText.text = defense.ToString();
        spdText.text = $"{attackSpeed} / {moveSpeed}";
    }

    void StatButtonClick(PointerEventData eventData)
    {
        if (!characterStatImage.gameObject.activeSelf)
            characterStatImage.gameObject.SetActive(true);
        else
            characterStatImage.gameObject.SetActive(false);
    }
}
