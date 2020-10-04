using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureStat : MonoBehaviour
{
    [SerializeField]
    protected string _id;

    [SerializeField]
    protected int _level;

    [SerializeField]
    protected int _hp;
    [SerializeField]
    protected int _maxHp;

    [SerializeField]
    protected int _attack;
    [SerializeField]
    protected int _defense;

    [SerializeField]
    protected float _attackSpeed;
    [SerializeField]
    protected float _moveSpeed;

    [SerializeField]
    protected int _attackRange;
    [SerializeField]
    protected int _viewRadius;
    [SerializeField]
    protected int _viewAngle;

    // 그냥 프로퍼티만 만들지 않고 굳이 위에 멤버변수를 만든 이유는, 유니티 툴 멤버변수들 보기위해서
    public string Id { get { return _id; } set { _id = value; } }

    public int Level {  get { return _level; } set { _level = value; } }

    public int Hp { get { return _hp; } set { _hp = value; } }
    public int MaxHp { get { return _maxHp; } set { _maxHp = value; } }

    public int Attack { get { return _attack; } set { _attack = value; } }
    public int Defense { get { return _defense; } set { _defense = value; } }

    public float AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

    public int AttackRange { get { return _attackRange; } set { _attackRange = value; } }
    public int ViewRadius { get { return _viewRadius; } set { _viewRadius = value; } }
    public int ViewAngle { get { return _viewAngle; } set { _viewAngle = value; } }

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
