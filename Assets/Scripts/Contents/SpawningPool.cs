using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    BoxCollider _spawnArea;
    int _monsterCount;

    void Start()
    {
        _spawnArea = gameObject.GetOrAddComponent<BoxCollider>();
        MonsterSpawn("Prefabs/Monster/Slime", gameObject.transform);
    }

    void Update()
    {
        
    }

    // 웨이브 몬스터는 ObjectPooling 할 필요 없다.
    void MonsterSpawn(string path, Transform parent = null)
    {    
        for (int i=(int)_spawnArea.transform.position.x; i<(int)_spawnArea.bounds.max.x; i++)
        {
            for (int j = (int)_spawnArea.transform.position.z; j < (int)_spawnArea.bounds.max.z; j++)
            {
                Vector3 pos = new Vector3(i, 0, j);
                Managers.Game.Spawn(Define.WorldObject.WaveMonster, "Prefabs/Monster/Slime", pos, parent);
                _monsterCount++;

                if (_monsterCount >= 3)
                    return;
            }
        }
    }
}
