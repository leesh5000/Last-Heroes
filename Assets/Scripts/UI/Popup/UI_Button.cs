using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_PopupBase
{
    [SerializeField]
    Text _text;

    enum Buttons
    {
        PointButton,
    }

    enum Texts
    {
        PointText,
        ScoreText,
    }

    enum GameObjects
    {
        TestObj,
    }

    enum Images
    {
        ItemIcon,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        BindUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.OnDrag);

        //GetButton((int)Buttons.PointButton).gameObject.BindUIEvent(OnButtonClicked, Define.UIEvent.Click);
        gameObject.BindUIEvent(OnButtonClicked, Define.UIEvent.OnPointerClick);
    }


    int _score = 0;
    public void OnButtonClicked(PointerEventData data)
    {
        _score++;
        // GetText((int)Texts.ScoreText).text = $"Score : {_score}";
        Get<Text>((int)Texts.ScoreText).text = $"Score : {_score}";
    }
}
