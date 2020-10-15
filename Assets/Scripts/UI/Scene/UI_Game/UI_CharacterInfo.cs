using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }

    enum Buttons
    {
        ATKButton,
        DEFButton,
        SPDButton,
        STRButton,
        AGIButton,
        INTButton,
    }

    public override void Init()
    {
        base.Init();

        Bind<Slider>(typeof(Sliders));

        Slider xpBarSlider = Get<Slider>((int)Sliders.XpBarSlider);
        Slider hpBarSlider = Get<Slider>((int)Sliders.HpBarSlider);
        Slider mpBarSlider = Get<Slider>((int)Sliders.MpBarSlider);

        Bind<Text>(typeof(Texts));

        Text characterNameText = Get<Text>((int)Texts.CharacterNameText);
        Text characterSubNameText = Get<Text>((int)Texts.CharacterSubNameText);

        Text hpText = Get<Text>((int)Texts.HPText);
        Text mpText = Get<Text>((int)Texts.MPText);

        Text atkText = Get<Text>((int)Texts.ATKText);
        Text defText = Get<Text>((int)Texts.DEFText);
        Text spdText = Get<Text>((int)Texts.SPDText);
        Text strText = Get<Text>((int)Texts.STRText);
        Text agiText = Get<Text>((int)Texts.AGIText);
        Text intText = Get<Text>((int)Texts.INTText);

        Dictionary<string, ContentsData.ChracterStat> statDict = Managers.Data.ChracterStatDict;
        ContentsData.ChracterStat stat = statDict[Managers.Game.Player.name];
        //characterSubNameText.text = stat.description;

        



    }


}
