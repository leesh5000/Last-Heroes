using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    Define.Scene _sceneType = Define.Scene.Default;

    public Define.Scene SceneType { get { return _sceneType; } protected set { _sceneType = value; } }

    // Awake()는 Start보다 먼저오고, 게임오브젝트가 꺼져있어도 작동된다.
    void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        // EventSystem이 없다면, 생성해주기
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj == null)
            Managers.Resource.Instantiate("Prefabs/UI/EventSystem").name = "@EventSystem";
    }

    public abstract void Clear();
}
