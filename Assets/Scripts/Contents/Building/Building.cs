using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    void Start()
    {
        Init();
    }

    void Update()
    {

    }

    public abstract void Init();
}
