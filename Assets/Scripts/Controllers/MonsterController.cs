using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : CreatureController
{
    MonsterStat _stat;
    GameObject _player;

    public override void Init()
    {
        WorldObjectType = Define.WorldObject.Monster;

        nma = Util.GetOrAddComponent<NavMeshAgent>(gameObject);

        _stat = gameObject.GetOrAddComponent<MonsterStat>();
        _stat.Id = gameObject.name;

        _player = Managers.Game.GetPlayer();

        _fov = gameObject.GetOrAddComponent<FieldOfView>();
        _fov.viewRadius = _stat.ViewRadius;
        _fov.viewAngle = _stat.ViewAngle;
        _fov.targetMask = (1 << (int)Define.Layer.Player);
    }

    protected override void UpdateIdle()
    {
        if (_fov.visibleTargets.Count != 0)
        {
            _lockTarget = _fov.visibleTargets.Dequeue();
            State = Define.State.Moving;
            return;
        }
    }

    protected override void UpdateMoving()
    {
        if (_fov.visibleTargets.Count == 0)
        {
            _lockTarget = null;
            State = Define.State.Idle;
            return;
        }

        if (_lockTarget != null)
        {
            DestPos = _lockTarget.position;
            float distance = (DestPos - transform.position).magnitude;

            if (distance <= _stat.AttackRange)
            {
                nma.SetDestination(transform.position);
                State = Define.State.Attack;
                return;
            }
        }

        float dist = (DestPos - transform.position).magnitude;
        Vector3 dir = (DestPos - transform.position).normalized;
        if (dist < 0.1f)
            State = Define.State.Idle;

        else
        {
            nma.SetDestination(DestPos);
            nma.speed = _stat.MoveSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }
    }

    protected override void UpdateAttack()
    {
        if (_lockTarget != null)
        {
            Vector3 dir = (_lockTarget.position - transform.position).normalized;
            Quaternion quaternion = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, 20 * Time.deltaTime);
        }
    }

    void OnHitEvent()
    {
        if (_lockTarget != null)
        {
            // 체력
            Stat targetStat = _lockTarget.GetComponent<Stat>();
            targetStat.OnAttacked(_stat);

            if (targetStat.Hp > 0)
            {
                float distance = (_lockTarget.transform.position - transform.position).magnitude;
                if (distance <= _stat.AttackRange)
                    State = Define.State.Attack;
                else
                    State = Define.State.Moving;
            }
            else
            {
                State = Define.State.Idle;
            }
        }
        else
        {
            State = Define.State.Idle;
        }
    }
}
