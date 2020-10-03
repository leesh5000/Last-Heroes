using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    public GameObject Original { get; private set; }
    public Transform Root { get; set; }

    Stack<Poolable> _poolableStack = new Stack<Poolable>();

    public void Init(GameObject original, int count)
    {
        Original = original;
        Root = new GameObject().transform;
        Root.name = $"{original.name}_Root";

        Push(CreatePoolable());

        //if (original.name.Contains("UI"))
        //{
        //    Push(CreatePoolable());
        //    return;
        //}
        
        //for (int i = 0; i < count; i++)
        //    Push(CreatePoolable());
    }

    Poolable CreatePoolable()
    {
        GameObject go = Object.Instantiate(Original);
        go.name = Original.name;

        return go.GetOrAddComponent<Poolable>();
    }

    public void Push(Poolable poolable)
    {
        if (poolable == null)
            return;

        //poolable.transform.parent = Root;
        poolable.transform.SetParent(Root);
        poolable.gameObject.SetActive(false);
        poolable.IsUsing = false;

        _poolableStack.Push(poolable);
    }

    public Poolable Pop(Transform parent)
    {
        Poolable poolable;

        if (_poolableStack.Count > 0)
            poolable = _poolableStack.Pop();
        else
            poolable = CreatePoolable();

        poolable.gameObject.SetActive(true);

        // DontDestroyOnLoad 해제용도
        if (parent == null)
            poolable.transform.SetParent(Managers.Scene.CurrentScene.transform);

        poolable.transform.SetParent(parent);
        poolable.IsUsing = true;

        return poolable;
    }
}
