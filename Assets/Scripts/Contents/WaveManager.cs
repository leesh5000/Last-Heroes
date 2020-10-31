using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWave;
    int reservedMonsterCount;
    int currentMonsterCount;
    public float remainingTime;

    GameObject[] MonsterWaves = new GameObject[5];

    void Start()
    {
        Managers.Game.WaveManager = gameObject;

        MonsterWaves[0] = Resources.Load<GameObject>("Prefabs/Monster/Slime");
        MonsterWaves[1] = Resources.Load<GameObject>("Prefabs/Monster/TurtleShell");
        MonsterWaves[2] = Resources.Load<GameObject>("Prefabs/Monster/Chest");
        MonsterWaves[3] = Resources.Load<GameObject>("Prefabs/Monster/Beholder");
        MonsterWaves[4] = Resources.Load<GameObject>("Prefabs/Monster/BlackKnight");

        //currentMonsterCount = Managers.Game.MonsterCount;

        currentWave = 1;
        remainingTime = 5.0f;
    }

    void Update()
    {
        if (Managers.Game.MonsterCount == 0 && reservedMonsterCount == 0)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }

            if (remainingTime < 0)
            {
                remainingTime = 5.0f;
                MonsterSpawn();
            }
        }
    }

    public void MonsterSpawn()
    {
        if (currentWave > MonsterWaves.Length) { return; }

        reservedMonsterCount = 3;

        while (reservedMonsterCount > 0)
        {

            Managers.Game.Spawn(Define.WorldObject.Monster, $"Prefabs/Monster/{MonsterWaves[currentWave - 1].name}", transform);
            reservedMonsterCount--;
        }

        currentWave++;
    }
}
