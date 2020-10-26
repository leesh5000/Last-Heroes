using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    BoxCollider _spawnPos;
    int _monsterCount;
    public Dictionary<int, string> WaveMonsterDic = new Dictionary<int, string>();

    void Start()
    {
        _spawnPos = gameObject.GetOrAddComponent<BoxCollider>();

        int wave = 1;
        if (Managers.Data.MonsterStatDict.ContainsValue($"Wave {wave++}"))
        {
            Managers.Data.MonsterStatDict.Con
        }
    }

    void Update()
    {
        
    }

    // 웨이브 몬스터는 ObjectPooling 할 필요 없다.
    void MonsterSpawn(string path, Transform parent = null)
    {
        string CurrentWaveMonster = 
        Managers.Game.Spawn(Define.WorldObject.Monster, $"Prefabs/Monster/{CurrentWaveMonster}", _spawnPos);
    }
}
