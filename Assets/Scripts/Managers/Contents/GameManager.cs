using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    //Dictionary<int, GameObject> _environments = new Dictionary<int, GameObject>();
    //Dictionary<int, GameObject> _montsers = new Dictionary<int, GameObject>();

    /* HashSet */
    //    - 특징
    //(1) 입력된 순서로 저장되지 않습니다.
    //(2) element의 중복을 허용하지 않습니다.
    //(3) null element를 허용합니다.
    //(4) 동기화처리가 되지 않습니다.
    //동기화 처리를 하기 위해서는 아래와 같이 객체를 생성해야 합니다.

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
