using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStat : MonoBehaviour
{
    [SerializeField]
    protected string _id;

    [SerializeField]
    protected int _level;
    [SerializeField]
    protected string _type;

    [SerializeField]
    protected int _attack;
    [SerializeField]
    protected int _attackSpeed;

    [SerializeField]
    public string Id { get { return _id; } set { _id = value; } }

    [SerializeField]
    public int Level { get { return _level; } set { _level = value; } }
    [SerializeField]
    public string Type { get { return _type; } set { _type = value; } }

    [SerializeField]
    public int Attack { get { return _attack; } set { _attack = value; } }
    [SerializeField]
    public int AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value; } }

    public void Awake()
    {
        Init();
    }

    public void Init()
    {
        SetStat(gameObject.name);
    }

    public void SetStat(string id)
    {
        Dictionary<string, ContentsData.ItemStat> statDict = Managers.Data.ItemStatDict;
        ContentsData.ItemStat stat = statDict[id];

        Id = stat.id;

        Level = stat.level;
        Type = stat.type;

        Attack = stat.attack;
        AttackSpeed = stat.attackSpeed;
    }

}