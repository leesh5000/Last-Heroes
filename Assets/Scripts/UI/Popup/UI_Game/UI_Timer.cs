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
    WaveManager waveManager;

    public override void Init()
    {
        Managers.UI.UI_Timer = gameObject;

        base.Init();

        Bind<Text>(typeof(Texts));
        timerText = Get<Text>((int)Texts.TimerText);

        waveManager = Managers.Game.WaveManager.GetComponent<WaveManager>();
    }

    private void Update()
    {
        timerText.text = $"WAVE {waveManager.currentWave}  :  " + Mathf.Ceil(waveManager.remainingTime).ToString();
    }
}
