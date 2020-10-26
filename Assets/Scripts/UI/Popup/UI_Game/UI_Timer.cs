using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : UI_SceneBase
{
    enum Texts
    {
        TimerText,
    }

    Text timerText;
    private float time;

    public Action TimeOutAction = null;

    public override void Init()
    {
        base.Init();

        Bind<Text>(typeof(Texts));
        timerText = Get<Text>((int)Texts.TimerText);

        time = 60.0f;
    }

    void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;

        timerText.text = $"WAVE {Managers.Game.CurrentWave}  :  "+Mathf.Ceil(time).ToString();

        if (time == 0)
        {
            TimeOutAction.Invoke();
            gameObject.SetActive(false);
        }
    }
}
