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
    public int _price;
    [SerializeField]
    public int _hp;
    [SerializeField]
    public int _attack;
    [SerializeField]
    public int _defense;
    [SerializeField]
    public float _moveSpeed;
    [SerializeField]
    public float _attackSpeed;

    public string Id { get { return _id; } set { _id = value; } }
    public string Class { get { return _class; } set { _class = value; } }
    public int Price { get { return _price; } set { _price = value; } }
    public int Hp { get { return _hp; } set { _hp = value; } }
    public int Attack { get { return _attack; } set { _attack = value; } }
    public int Defense { get { return _defense; } set { _defense = value; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    public float AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value; } }

    public void Start()
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
        Price = stat.Price;
        Hp = stat.HP;
        Attack = stat.Attack;
        Defense = stat.Defense;
        MoveSpeed = stat.MoveSpeed;
        AttackSpeed = stat.AttackSpeed;
    }

    public List<string> MakeListToItemInfo()
    {
        List<string> list = new List<string>();

        list.Add(Class);
        list.Add("Price " + Price.ToString());

        if (Hp != 0) list.Add("+ HP " + Hp.ToString());
        if (Attack != 0) list.Add("+ Attack " + Attack.ToString());
        if (Defense != 0) list.Add("+ Defense " + Defense.ToString());
        if (MoveSpeed != 0) list.Add("+ Move Speed " + MoveSpeed.ToString());
        if (AttackSpeed != 0) list.Add("+ Attack Speed " + AttackSpeed.ToString());

        return list;
    }

    public List<string> MakeListToCharacterStat()
    {
        List<string> list = new List<string>();

        list.Add(Hp.ToString());
        list.Add(Attack.ToString());
        list.Add(Defense.ToString());
        list.Add(MoveSpeed.ToString());
        list.Add(AttackSpeed.ToString());

        return list;
    }
}