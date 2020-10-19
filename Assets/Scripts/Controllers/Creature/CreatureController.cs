using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class CreatureController : MonoBehaviour
{
    [SerializeField]
    protected Define.State _state = Define.State.Idle;

    [SerializeField]
    protected Vector3 DestPos { get; set; }

    [SerializeField]
    protected Transform _lockTarget;

    [SerializeField]
    protected FieldOfView _fov;

    public CreatureStat Stat { get; set; }

    public Define.WorldObject WorldObjectType { get; protected set; } = Define.WorldObject.Unknown;
    public Transform LockTarget { get { return _lockTarget; } set { _lockTarget = value; } }
    protected NavMeshAgent nma;

    // State를 바꾸고 -> Animation 재생 보다는 State를 바꿀때 동시에 Animation 재생하기
    // 오버라이딩은 "재정의"
    public virtual Define.State State
    {
        get { return _state; }
        set
        {
            _state = value;

            Animator anim = GetComponent<Animator>();
            switch (_state)
            {
                case Define.State.Idle:
                    {
                        anim.CrossFade("IDLE", 0.1f);
                        break;
                    }

                case Define.State.Moving:
                    {
                        anim.CrossFade("RUN", 0.1f);
                        break;
                    }

                case Define.State.Attack:
                    {
                        anim.CrossFade("ATTACK", 0.1f);
                        break;
                    }
            }
        }
    }
    
    private void Start()
    {
        if (gameObject.GetComponentInChildren<UI_HPBar>() == null)
            Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);

        Init();
    }

    void Update()
    {
        //if (gameObject.layer == (int)Define.Layer.Monster)
        //{
        //    Debug.Log($"Name & State :: {gameObject.name} & {State}");
        //    if (LockTarget != null)
        //        Debug.Log($"LockTarget :: {LockTarget.name}");
        //}

        switch (State)
        {
            case Define.State.Idle:
                UpdateIdle();
                break;

            case Define.State.Moving:
                UpdateMoving();
                break;

            case Define.State.Attack:
                UpdateAttack();
                break;
        }
    }

    public abstract void Init();

    protected virtual void UpdateIdle() { }
    protected virtual void UpdateMoving() { }
    protected virtual void UpdateAttack() { }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log($"Collision Name : {collision.collider.name}");
    //}
}
