using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStat : CreatureStat
{
    public Transform HUDPos { get; set; }

    public override void Init()
    {
        SetStat(Define.WorldObject.Monster, gameObject.name);

        HUDPos = transform.Find("HUDPos");
    }

    public override void SetStat(Define.WorldObject type, string id)
    {
        Dictionary<string, ContentsData.MonsterStat> statDict = Managers.Data.MonsterStatDict;
        ContentsData.MonsterStat stat = statDict[id];

        Id = stat.ID;
        MaxHp = stat.HP;
        Hp = int.Parse(MaxHp.ToString());
        MaxMp = 0;
        Mp = 0;
        AttackRange = stat.AttackRange;
        AttackSpeed = stat.AttackSpeed;
        MoveSpeed = stat.MoveSpeed;
        Attack = stat.Attack;
        Defense = stat.Defense;
        Exp = stat.EXP;
        Gold = stat.Gold;
    }

    public override void OnAttacked(CreatureStat attackerStat)
    {
        int damage = Mathf.Max(0, attackerStat.Attack - Defense);
        Hp -= damage;

        UI_Damage damageText = Managers.UI.MakeWorldSpaceUI<UI_Damage>();
        damageText.transform.position = HUDPos.position;
        damageText.GetComponent<Text>().text = damage.ToString();

        if (Hp <= 0)
        {
            Hp = 0;
            OnDead(attackerStat);
        }
    }

    public override void OnDead(CreatureStat attackerStat)
    {
        CharacterStat playerStat = attackerStat as CharacterStat;
        if (playerStat != null)
        {
            playerStat.CurrentExp += Exp;
            playerStat.Gold += Gold;
            // 여기서 플레이어 스텟에 접근하지말고, 플레이어 스텟에서 레벨업 체크 로직을 수행할 것
        }

        Managers.Game.DeSpawn(gameObject);
    }
}
