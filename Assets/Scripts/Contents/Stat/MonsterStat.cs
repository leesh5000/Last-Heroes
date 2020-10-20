using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStat : CreatureStat
{
    public Transform HUD_DamagePos { get; set; }
    public Transform HUD_ExpPos { get; set; }
    public Transform HUD_GoldPos { get; set; }

    public override void Init()
    {
        SetStat(Define.WorldObject.Monster, gameObject.name);

        HUD_DamagePos = transform.Find("HUD_DamagePos");
        HUD_ExpPos = transform.Find("HUD_ExpPos");
        HUD_GoldPos = transform.Find("HUD_GoldPos");
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

        HUD_Damage HUDDamage = Managers.UI.MakeWorldSpaceUI<HUD_Damage>();
        HUDDamage.transform.position = HUD_DamagePos.position;
        HUDDamage.GetComponent<TextMeshPro>().text = damage.ToString();

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
            HUD_Exp HUDExp = Managers.UI.MakeWorldSpaceUI<HUD_Exp>();
            HUDExp.transform.position = HUD_ExpPos.position;
            HUDExp.GetComponent<TextMeshPro>().text = "+" + Exp.ToString();

            playerStat.Gold += Gold;
            HUD_Gold HUDGold = Managers.UI.MakeWorldSpaceUI<HUD_Gold>();
            HUDGold.transform.position = HUD_GoldPos.position;
            HUDGold.GetComponent<TextMeshPro>().text = "+" + Gold.ToString();
        }

        Managers.Game.DeSpawn(gameObject);
    }
}
