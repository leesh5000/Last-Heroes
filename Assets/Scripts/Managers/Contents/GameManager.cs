using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public GameObject Ui_LoginScene { get; set; }
    public GameObject Ui_LobbyScene { get; set; }
    public GameObject Ui_GameScene { get; set; }

    public GameObject Statue { get; set; }

    public GameObject Player { get; set; }
    public string PlayerName { get; set; }

    public GameObject Shop { get; set; }

    public GameObject MainCamera { get; set; }
    public GameObject MinimapCamera { get; set; }
    public GameObject WorldmapCamera { get; set; }

    public GameObject SpawningPool { get; set; }
    
    GameObject _player;
    private int _monsterCount = 0;
    public int CurrentWave { get; set; } = 1;

    public Action<int> OnSpawnEvent;

    public GameObject GetPlayer() { return _player; }

    public GameObject Spawn(Define.WorldObject type, string path, Transform parent = null)
    {
        GameObject go = Managers.Resource.Instantiate(path, parent);

        switch (type)
        {
            case Define.WorldObject.Chracter:
                {
                    _player = go;
                }
                break;

            case Define.WorldObject.Monster:
                {
                    _monsterCount++;
                }
                break;
        }

        return go;
    }

    public GameObject Spawn(Define.WorldObject type, string path, Vector3 pos, Transform parent = null)
    {
        GameObject go = Managers.Resource.Instantiate(path, pos, parent);

        switch (type)
        {
            case Define.WorldObject.Chracter:
                {
                    _player = go;
                }
                break;

            case Define.WorldObject.Monster:
                {
                    _monsterCount++;
                }
                break;
        }

        return go;
    }

    public void DeSpawn(GameObject go)
    {
        Define.WorldObject type = GetWorldObjectType(go);

        switch (type)
        {
            case Define.WorldObject.Chracter:
                {
                    if (_player == go)
                        _player = null;
                }
                break;

            case Define.WorldObject.Monster:
                {
                    _monsterCount--;

                    // 몬스터가 0마리가 되면, 게임 매니저에서 타이머UI를 열어주고, 타이머UI에서 시간이 다 되면, SpawningPool의 몬스터를 다음 웨이브
                    // 몬스터로 바꿔주
                    if (_monsterCount == 0)
                    {
                        CurrentWave += 1;
                        Managers.UI.UI_Timer.SetActive(true);

                    }
                }
                break;
        }

        Managers.Resource.Destroy(go);
    }

    public Define.WorldObject GetWorldObjectType(GameObject go)
    {
        CreatureController cc = go.GetComponent<CreatureController>();

        if (cc == null)
            return Define.WorldObject.Unknown;

        return cc.WorldObjectType;
    }
}
