using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _dict = new Dictionary<Type, UnityEngine.Object[]>();

    public abstract void Init();

    private void Start()
    {
        Init();
    }

    // 게임오브젝트 안에 있는 UI 컴포넌트들을 찾아서 Dic에 넣는 Bind
    protected void Bind<T>(Type enumName) where T : UnityEngine.Object
    {
        // Enum들을 string[]배열로 가져온다.
        string[] names = Enum.GetNames(enumName);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _dict.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objects[i] = Util.FindChildren(gameObject, names[i], true);
            else
                objects[i] = Util.FindChildren<T>(gameObject, names[i], true);
        }
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_dict.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[idx] as T;
    }

    protected Text GetText(int idx) { return Get<Text>(idx); }
    protected Image GetImage(int idx) { return Get<Image>(idx); }
    protected Button GetButton(int idx) { return Get<Button>(idx); }
    protected GameObject GetGameObject(int idx) { return Get<GameObject>(idx); }

    public static void BindUIEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type)
    {
        UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);
        
        switch (type)
        {
            case Define.UIEvent.OnPointerDown:
                evt.OnPointerDownAction -= action;
                evt.OnPointerDownAction += action;
                break;

            case Define.UIEvent.OnPointerUp:
                evt.OnPointerUpAction -= action;
                evt.OnPointerUpAction += action;
                break;

            case Define.UIEvent.OnPointerClick:
                evt.OnPointerClickAction -= action;
                evt.OnPointerClickAction += action;
                break;

            case Define.UIEvent.OnBeginDrag:
                evt.OnBeginDragAction -= action;
                evt.OnBeginDragAction += action;
                break;

            case Define.UIEvent.OnDrag:
                evt.OnDragAction -= action;
                evt.OnDragAction += action;
                break;

            case Define.UIEvent.OnEndDrag:
                evt.OnEndDragAction -= action;
                evt.OnEndDragAction += action;
                break;

            case Define.UIEvent.OnDrop:
                evt.OnDropAction -= action;
                evt.OnDropAction += action;
                break;
        }
    }
}
