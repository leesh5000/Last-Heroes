using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : CreatureStat
{
    [SerializeField]
    protected int _level;
    [SerializeField]
    protected string _subName;
    [SerializeField]
    protected string _description;
    [SerializeField]
    protected int _str;
    [SerializeField]
    protected int _agi;
    [SerializeField]
    protected int _int;
    [SerializeField]
    private int _currentExp;

    public int Level { get { return _level; } set { _level = value; } }
    public string SubName { get { return _subName; } set { _subName = value; } }
    public string Description { get { return _description; } set { _description = value; } }
    public int STR { get { return _str; } set { _str = value; } }
    public int AGI { get { return _agi; } set { _agi = value; } }
    public int INT { get { return _int; } set { _int = value; } }
    public int CurrentExp { get { return _currentExp; } set { _currentExp = value; } }

    // 레벨업체크도 여기서 함!
    public override int Exp
    {
        get { return _exp; }
        set
        {
            _exp = value;

            if (CurrentExp >= _exp)
                switch (gameObject.name)
                {
                    case "Knight":
                        {
                            CurrentExp = 0;
                            _exp *= 2;
                        }
                        break;

                    case "Archer":
                        {

                        }
                        break;
                }

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

    public override void Init()
    {
        SetStat(Define.WorldObject.Chracter, gameObject.name);
    }

    public override void SetStat(Define.WorldObject type, string id)
    {
        Dictionary<string, ContentsData.CharacterStat> statDict = Managers.Data.CharacterStatDict;
        
        ContentsData.CharacterStat stat = statDict[id];

        Id = stat.ID;
        MaxHp = stat.HP;
        Hp = int.Parse(MaxHp.ToString());
        MaxMp = stat.MP;
        Mp = int.Parse(MaxMp.ToString());
        Attack = stat.Attack;
        Defense = stat.Defense;
        AttackSpeed = stat.AttackSpeed;
        MoveSpeed = stat.MoveSpeed;
        AttackRange = stat.AttackRange;

        Level = stat.Level;
        SubName = stat.SubName;
        Description = stat.Description;
        STR = stat.STR;
        AGI = stat.AGI;
        INT = stat.INT;
        Exp = stat.EXP;

        Gold = 1000;
        CurrentExp = 0;
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

    public void ItemEquipment(ItemStat itemStat)
    {
        Hp += itemStat.Hp;
        Attack += itemStat.Attack;
        Defense += itemStat.Defense;
        MoveSpeed += itemStat.MoveSpeed;

        AttackSpeed += itemStat.AttackSpeed;
        Animator playerAnimator = Managers.Game.Player.GetComponent<PlayerController>().PlayerAnimator;
        playerAnimator.SetFloat("AttackSpeed", AttackSpeed);
    }

    public void ItemUnEquipment(ItemStat itemStat)
    {
        Hp -= itemStat.Hp;
        Attack -= itemStat.Attack;
        Defense -= itemStat.Defense;
        MoveSpeed -= itemStat.MoveSpeed;

        AttackSpeed -= itemStat.AttackSpeed;
        Animator playerAnimator = Managers.Game.Player.GetComponent<PlayerController>().PlayerAnimator;
        playerAnimator.SetFloat("AttackSpeed", AttackSpeed);
    }
}
