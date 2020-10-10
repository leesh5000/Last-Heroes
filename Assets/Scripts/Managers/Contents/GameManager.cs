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

    public GameObject MainCamera { get; set; }
    public GameObject MinimapCamera { get; set; }
    public GameObject WorldmapCamera { get; set; }

    public GameObject SpawningPool { get; set; }
    
    GameObject _player;

    public Action<int> OnSpawnEvent;

    public GameObject GetPlayer() { return _player; }

    public GameObject Spawn(Define.WorldObject type, string path, Transform parent = null)
    {
        GameObject go = Managers.Resource.Instantiate(path, parent);

        switch (type)
        {
            case Define.WorldObject.WaveMonster:
                break;

            case Define.WorldObject.Monster:
                break;

            case Define.WorldObject.Chracter:
                _player = go;
                break;
        }

        return go;
    }

    public GameObject Spawn(Define.WorldObject type, string path, Vector3 pos, Transform parent = null)
    {
        GameObject go = Managers.Resource.Instantiate(path, pos, parent);

        switch (type)
        {
            case Define.WorldObject.WaveMonster:
                break;

            case Define.WorldObject.Monster:
                break;

            case Define.WorldObject.Chracter:
                _player = go;
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

            case Define.WorldObject.WaveMonster:
                {

                }
                break;

            case Define.WorldObject.Monster:
                {

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
