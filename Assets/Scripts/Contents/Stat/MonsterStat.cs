using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : CreatureStat
{
    public override void Init()
    {
        SetStat(Define.WorldObject.WaveMonster, Id);
    }

    public override void SetStat(Define.WorldObject type, string id)
    {
        Dictionary<string, ContentsData.WaveMonsterStat> statDict = Managers.Data.WaveMonsterStatDict;
        ContentsData.WaveMonsterStat stat = statDict[id];

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
        ChracterStat characterStat = attackerStat as ChracterStat;
        if (characterStat != null)
        {
            characterStat.Exp += 5;
            // 여기서 플레이어 스텟에 접근하지말고, 플레이어 스텟에서 레벨업 체크 로직을 수행할 것
        }

        Managers.Game.DeSpawn(gameObject);
    }
}
