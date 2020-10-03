using System;
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
    public Dictionary<string, ContentsData.ChracterStat> ChracterStatDict { get; private set; } = new Dictionary<string, ContentsData.ChracterStat>();

    public Dictionary<string, ContentsData.WaveMonsterStat> WaveMonsterStatDict { get; private set; } = new Dictionary<string, ContentsData.WaveMonsterStat>();


    public void Init()
    {
        ChracterStatDict = LoadJson<ContentsData.ChracterStatDataLoader, string, ContentsData.ChracterStat>("Data/ChracterStatData").ConvertDict();

        WaveMonsterStatDict = LoadJson<ContentsData.WaveMonsterStatDataLoader, string, ContentsData.WaveMonsterStat>("Data/WaveMonsterStatData").ConvertDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>(path);
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
