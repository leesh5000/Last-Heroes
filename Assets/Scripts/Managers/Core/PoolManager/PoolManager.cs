using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PoolManager는 ResourceManager를 보조
// 오브젝트들을 캐싱
public class PoolManager
{
    Dictionary<string, Pool> _poolDcit = new Dictionary<string, Pool>();

    Transform _root;

    public void Init()
    {
        if (_root == null)
        {
            _root = new GameObject { name = "@Pool_Root" }.transform;
            Object.DontDestroyOnLoad(_root);
        }    
    }

    public void CreatePool(GameObject original, int count = 5)
    {
        Pool pool = new Pool();
        pool.Init(original, count);
        pool.Root.parent = _root;

        _poolDcit.Add(original.name, pool);
    }

    // 다 썼으면 대기실에 넣기
    public void Push(Poolable poolable)
    {
        string name = poolable.gameObject.name;

        if (_poolDcit.ContainsKey(name) == false)
        {
            Object.Destroy(poolable.gameObject);
            return;
        }

        _poolDcit[name].Push(poolable);
    }

    // 필요하면 대기실에서 빼오기 (없으면 생성하고 빼오기)
    public Poolable Pop(GameObject original, Transform parent = null)
    {
        if (_poolDcit.ContainsKey(original.name) == false)
            CreatePool(original);

        Pool pool = _poolDcit[original.name];
        return pool.Pop(parent);
    }

    public GameObject GetOriginal(string name)
    {
        if (_poolDcit.ContainsKey(name) == false)
            return null;

        return _poolDcit[name].Original;
    }
    
    public void Clear()
    {
        foreach (Transform child in _root)
            GameObject.Destroy(child.gameObject);

        _poolDcit.Clear();
    }
}
