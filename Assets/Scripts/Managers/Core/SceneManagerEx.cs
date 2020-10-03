using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }

    // 원본 LoadScene 랩핑
    public void LoadScene(Define.Scene type)
    {
        Managers.Clear();
        SceneManager.LoadScene(GetSceneName(type));
    }

    string GetSceneName(Define.Scene type)
    {
        string name = Enum.GetName(typeof(Define.Scene), type);     
        return name;
    }

    public void Clear()
    {
        CurrentScene.Clear();
    }
}
