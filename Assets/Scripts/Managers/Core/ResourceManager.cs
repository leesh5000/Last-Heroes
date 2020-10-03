using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 프리팹이 언제 로드되고 생성되는지 알기 위해서 ResourceManager에서 Load, Instantiate 함수를 랩핑해서 사용
public class ResourceManager
{
    // 로드는 내가 만든 Resources 폴더 내에 있는 Object를 상속받는 모든 것들을 가져올 수 있음
    public T Load<T>(string path) where T : Object
    {
        // 만약 Pools에 path 이름을 갖는 Pool이 있으면, 그걸 리턴
        if (typeof(T) == typeof(GameObject))
        {
            string name = path;
            int idx = name.LastIndexOf('/');
            if (idx >= 0)
                name = name.Substring(idx + 1);

            GameObject go = Managers.Pool.GetOriginal(name);
            if (go != null)
                return go as T;
        }

        return Resources.Load<T>(path);
    }


    // Instantiate는 게임 세상에 GameObject를 생성해주는 함수
    public GameObject Instantiate(string path, Transform parent = null)
    {
        // original을 로드하고
        GameObject original = Load<GameObject>(path);
        if (original == null)
        {
            Debug.Log($"Failed to Load Prefab : {path}");
            return null;
        }

        // Poolable이라면, 여기서 실제로 게임세상에 생성
        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;

        return go;
    }

    public GameObject Instantiate(string path, Vector3 pos, Transform parent = null)
    {
        // original을 로드하고
        GameObject original = Load<GameObject>(path);
        if (original == null)
        {
            Debug.Log($"Failed to Load Prefab : {path}");
            return null;
        }

        // Poolable이라면, 여기서 실제로 게임세상에 생성
        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;

        GameObject go = Object.Instantiate(original, pos, Quaternion.identity, parent);
        go.name = original.name;

        return go;
    }

    // 오버로딩 버전
    public T Instantiate<T>(string path, Transform parent = null) where T : Object
    {
        T original = Load<T>(path);

        if (original == null)
        {
            Debug.Log($"Failed to Load original : {path}");
            return null;
        }

        return Object.Instantiate<T>(original);
    }


    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Poolable poolable = go.GetComponent<Poolable>();
        if (poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }

        Object.Destroy(go);
    }

    public void Destroy(GameObject go, float t)
    {
        if (go == null)
            return;

        Object.Destroy(go, t);
    }
}
