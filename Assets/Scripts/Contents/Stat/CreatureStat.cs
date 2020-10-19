using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureStat : MonoBehaviour
{
    [SerializeField]
    protected string _id;
    [SerializeField]
    protected int _hp;
    [SerializeField]
    protected int _maxHp;
    [SerializeField]
    protected int _mp;
    [SerializeField]
    protected int _maxMp;
    [SerializeField]
    protected float _attackRange;
    [SerializeField]
    protected float _attackSpeed;
    [SerializeField]
    protected float _moveSpeed;
    [SerializeField]
    protected int _attack;
    [SerializeField]
    protected int _defense;
    [SerializeField]
    protected int _exp;
    [SerializeField]
    protected int _gold;

    // 그냥 프로퍼티만 만들지 않고 굳이 위에 멤버변수를 만든 이유는, 유니티 툴 멤버변수들 보기위해서
    public string Id { get { return _id; } set { _id = value; } }
    public int Hp { get { return _hp; } set { _hp = value; } }
    public int MaxHp { get { return _maxHp; } set { _maxHp = value; } }
    public int Mp { get { return _mp; } set { _mp = value; } }
    public int MaxMp { get { return _maxMp; } set { _maxMp = value; } }
    public int Attack { get { return _attack; } set { _attack = value; } }
    public int Defense { get { return _defense; } set { _defense = value; } }
    public float AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    public float AttackRange { get { return _attackRange; } set { _attackRange = value; } }
    public virtual int Exp { get { return _exp; } set { _exp = value; } }
    public int Gold { get { return _gold; } set { _gold = value; } }

    // 엄청 빨리 실행되어야하면, Awake 사용!
    public void Awake()
    {
        Init();
    }

    public abstract void Init();

    public virtual void SetStat(Define.WorldObject type, string Id) { }
    public virtual void OnAttacked(CreatureStat attackerStat) { }
    public virtual void OnDead(CreatureStat attackerStat) { }
}
