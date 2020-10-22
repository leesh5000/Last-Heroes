using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStat : MonoBehaviour
{
    [SerializeField]
    public string _id;
    [SerializeField]
    public string _class;
    [SerializeField]
    public int _gold;
    [SerializeField]
    public int _hp;
    [SerializeField]
    public int _attack;
    [SerializeField]
    public int _defense;
    [SerializeField]
    public float _moveSpeed;

    public string Id { get { return _id; } set { _id = value; } }
    public string Class { get { return _class; } set { _class = value; } }
    public int Gold { get { return _gold; } set { _gold = value; } }
    public int Hp { get { return _hp; } set { _hp = value; } }
    public int Attack { get { return _attack; } set { _attack = value; } }
    public int Defense { get { return _defense; } set { _defense = value; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

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

        Id = stat.ID;
        Class = stat.Class;
        Gold = stat.Gold;
        Hp = stat.HP;
        Attack = stat.Attack;
        Defense = stat.Defense;
        MoveSpeed = stat.MoveSpeed;
    }

    public List<string> MakeList()
    {
        List<string> list = new List<string>();

        list.Add(Class);
        list.Add("Price " + Gold.ToString());

        if (Hp != 0) list.Add("+ HP " + Hp.ToString());
        if (Attack != 0) list.Add("+ Attack " + Attack.ToString());
        if (Defense != 0) list.Add("+ Defense " + Defense.ToString());
        if (MoveSpeed != 0) list.Add("+ Move Speed " + MoveSpeed.ToString());

        return list;
    }
}