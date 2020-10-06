using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Util
{
    // 게임오브젝트 내에 자식들의 컴포넌트를 찾아주는 FindChildren
    public static T FindChildren<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if (recursive == false)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }

        else
        {
            // GetComponentsInChildren 은 재귀적으로 찾아주는 함수
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }
        
        return null;
    }

    // 게임오브젝트 내에 자식 게임오브젝트를 찾아주는 FindChildren
    public static GameObject FindChildren(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChildren<Transform>(go, name, recursive);

        if (transform == null)
            return null;
        else
            return transform.gameObject;
    }

    public static T GetOrAddComponent<T> (GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();

        return component;
    }

    public static bool IsValid(GameObject go)
    {
        if (go == null)
            return false;

        if (go.activeSelf == false)
            return false;

        return true;
    }
}
