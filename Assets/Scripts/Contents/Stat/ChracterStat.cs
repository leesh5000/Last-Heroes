using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterStat : CreatureStat
{
    [SerializeField]
    float _exp;

    [SerializeField]
    int _gold;

    // 레벨업체크도 여기서 함!
    public float Exp
    {
        get { return _exp; }
        set
        {
            _exp = value;

            //int currentLevel = Level;
            //while (true)
            //{
            //    ContentsData.ChracterStat stat;
            //    if (Managers.Data.ChracterStatDict.TryGetValue(Level + 1, out stat) == false)
            //        break;

            //    if (_exp < stat.totalExp)
            //        break;

            //    Id++;
            //    Debug.Log("LEVEL UP!");
            //}

            //if (Level != currentLevel)
            //{
            //    currentLevel = Level;
            //    SetStat(Define.WorldObject.Chracter, Id);
            //}
        }
    }

    public int Gold { get { return _gold; } set { _gold = value; } }

    public override void Init()
    {
        SetStat(Define.WorldObject.Chracter, gameObject.name);
    }

    public override void SetStat(Define.WorldObject type, string id)
    {
        Dictionary<string, ContentsData.ChracterStat> statDict = Managers.Data.ChracterStatDict;
        ContentsData.ChracterStat stat = statDict[id];

        Level = stat.level;

        Hp = stat.maxHp;
        MaxHp = stat.maxHp;

        Attack = stat.attack;
        Defense = stat.defense;

        AttackSpeed = stat.attackSpeed;
        MoveSpeed = stat.moveSpeed;

        AttackRange = stat.attackRange;
        ViewRadius = stat.viewRadius;
        ViewAngle = stat.viewAngle;
    }

    public override void OnAttacked(CreatureStat attackerStat)
    {
        int damage = Mathf.Max(0, attackerStat.Attack - Defense);
        Hp -= damage;

        if (Hp <= 0)
        {
            Hp = 0;
            OnDead(attackerStat);
        }
    }

    public override void OnDead(CreatureStat attackerStat)
    {
        Debug.Log("Player Dead!");
    }
}
