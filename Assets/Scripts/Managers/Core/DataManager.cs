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

    public void Init()
    {
        ItemStatDict = LoadJson<ContentsData.ItemStatDataLoader, string, ContentsData.ItemStat>("Data/ItemStatData").ConvertDict();

        ChracterStatDict = LoadJson<ContentsData.ChracterStatDataLoader, string, ContentsData.ChracterStat>("Data/ChracterStatData").ConvertDict();

        MonsterStatDict = LoadJson<ContentsData.MonsterStatDataLoader, string, ContentsData.MonsterStat>("Data/MonsterStatData").ConvertDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>(path);
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
