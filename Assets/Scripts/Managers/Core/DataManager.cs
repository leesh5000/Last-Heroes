﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> ConvertDict();
}

public class DataManager
{
    public Dictionary<string, ContentsData.ItemStat> ItemStatDict { get; private set; } = new Dictionary<string, ContentsData.ItemStat>();

    public Dictionary<string, ContentsData.ChracterStat> ChracterStatDict { get; private set; } = new Dictionary<string, ContentsData.ChracterStat>();

    public Dictionary<string, ContentsData.MonsterStat> MonsterStatDict { get; private set; } = new Dictionary<string, ContentsData.MonsterStat>();

    public Dictionary<int, ContentsData.WaveManager> WaveManagerDict { get; private set; } = new Dictionary<int, ContentsData.WaveManager>();

    public void Init()
    {
        ItemStatDict = LoadJson<ContentsData.ItemStatData, string, ContentsData.ItemStat>("Data/ItemStatData").ConvertDict();

        ChracterStatDict = LoadJson<ContentsData.ChracterStatData, string, ContentsData.ChracterStat>("Data/ChracterStatData").ConvertDict();

        MonsterStatDict = LoadJson<ContentsData.MonsterStatData, string, ContentsData.MonsterStat>("Data/MonsterStatData").ConvertDict();

        WaveManagerDict = LoadJson<ContentsData.WaveManagerData, int, ContentsData.WaveManager>("Data/MonsterWaveData").ConvertDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>(path);
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
