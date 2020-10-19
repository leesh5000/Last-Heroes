using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.AI;

public class WaveMonsterController : CreatureController
{
    public override void Init()
    {
        WorldObjectType = Define.WorldObject.Monster;

        gameObject.layer = (int)Define.Layer.WaveMonster;

        // NavMeshAgent
        nma = Util.GetOrAddComponent<NavMeshAgent>(gameObject);

        // 웨이브 몬스터 스텟 정보 가져오기

        Creature monster = gameObject.GetComponent(gameObject.name) as Creature;
        Stat = monster.Stat;

        _fov = gameObject.GetOrAddComponent<FieldOfView>();
        _fov.targetMask = (1 << (int)Define.Layer.Player);
    }

    protected override void UpdateIdle()
    {
        if (_fov.visibleTargets.Count == 0 && Managers.Game.Statue != null)
        {
            _lockTarget = Managers.Game.Statue.transform;
            State = Define.State.Moving;
            return;
        }

        if (_fov.visibleTargets.Count != 0)
        {
            _lockTarget = _fov.visibleTargets.Dequeue();
            State = Define.State.Moving;
            return;
        }
    }

    protected override void UpdateMoving()
    {
        // 최초로 LockTarget이 죽었는지 검사
        if (_lockTarget == null)
        {
            State = Define.State.Idle;
            nma.SetDestination(transform.position);
            return;
        }

        // 플레이어를 추적 중에 플레이어가 시야에서 사라졌다면,
        if (_fov.visibleTargets.Count == 0 && _lockTarget == Managers.Game.Player.transform)
        {
            _lockTarget = Managers.Game.Statue.transform;
        }

        // 석상을 추적 중에 플레이어가 발견됐다면,
        if (_fov.visibleTargets.Count != 0 && _lockTarget == Managers.Game.Statue.transform)
        {
            _lockTarget = Managers.Game.Player.transform;
        }

        if (_lockTarget != null)
        {
            DestPos = _lockTarget.position;
            float distance = (DestPos - transform.position).magnitude;

            if (distance <= Stat.AttackRange)
            {
                nma.SetDestination(transform.position);
                State = Define.State.Attack;
                return;
            }
        }

        float dist = (DestPos - transform.position).magnitude;
        Vector3 dir = (DestPos - transform.position).normalized;
        if (dist < 0.1f)
        {
            State = Define.State.Idle;
            nma.SetDestination(transform.position);
        }

        else
        {
            nma.SetDestination(DestPos);
            nma.speed = Stat.MoveSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }
    }

    protected override void UpdateAttack()
    {
        // 최초로 LockTarget이 죽었는지 검사
        if (_lockTarget == null)
        {
            State = Define.State.Idle;
            nma.SetDestination(transform.position);
            return;
        }

        // 석상을 공격 중에 플레이어가 발견됐다면,
        if (_lockTarget == Managers.Game.Statue.transform && _fov.visibleTargets.Count != 0)
        {
            //_lockTarget = _fov.visibleTargets.Dequeue();
            State = Define.State.Moving;
            return;
        }

        // 플레이어를 공격 중 일때, 플레이어가 사라지면 Statue를 추적하기 
        if (_fov.visibleTargets.Count == 0 && _lockTarget == Managers.Game.Player.transform)
        {
            _lockTarget = Managers.Game.Statue.transform;
            State = Define.State.Moving;
            return;
        }

        if (_lockTarget != null)
        {
            DestPos = _lockTarget.position;
            float distance = (DestPos - transform.position).magnitude;

            if (distance > Stat.AttackRange)
            {
                nma.SetDestination(transform.position);
                State = Define.State.Moving;
                return;
            }

            Vector3 dir = (_lockTarget.position - transform.position).normalized;
            Quaternion quaternion = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, 20 * Time.deltaTime);
        }
    }

    void OnHitEvent()
    {
        if (_lockTarget != null)
        {
            // 데미지 처리는 공격을 받는 대상이 하는게 훨씬 좋다. (각종 버프같은 것들 때문에)
            CreatureStat targetStat = _lockTarget.GetComponent<CreatureStat>();

            if (targetStat != null)
                targetStat.OnAttacked(Stat);
        }
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.InteropServices.ComTypes;
//using UnityEngine;
//using UnityEngine.AI;

//public class WaveMonsterController : CreatureController
//{
//    WaveMonsterStat _stat;

//    GameObject _player;
//    GameObject _statue;

//    float _attackRange = 3;

//    public override void Init()
//    {
//        WorldObjectType = Define.WorldObject.WaveMonster;

//        nma = Util.GetOrAddComponent<NavMeshAgent>(gameObject);

//        _stat = gameObject.GetOrAddComponent<WaveMonsterStat>();
//        _stat.Id = gameObject.name;

//        _fov = gameObject.GetOrAddComponent<FieldOfView>();
//        _fov.targetMask = (1 << (int)Define.Layer.Player);
//        _fov.viewRadius = _stat.ViewRadius;
//        _fov.viewAngle = _stat.ViewAngle;

//        _player = Managers.Game.GetPlayer();

//        _statue = GameObject.Find("Statue");
//    }

//    protected override void UpdateIdle()
//    {
//        if (_fov.visibleTargets.Count == 0 && _statue != null)
//        {
//            _lockTarget = _statue.transform;
//            State = Define.State.Moving;
//            return;
//        }

//        if (_fov.visibleTargets.Count != 0)
//        {
//            _lockTarget = _fov.visibleTargets.Dequeue();
//            State = Define.State.Moving;
//            return;
//        }
//    }

//    protected override void UpdateMoving()
//    {
//        // 최초로 LockTarget이 죽었는지 검사
//        if (_lockTarget == null)
//        {
//            State = Define.State.Idle;
//            nma.SetDestination(transform.position);
//            return;
//        }

//        // 플레이어를 추적 중에 플레이어가 시야에서 사라졌다면,
//        if (_fov.visibleTargets.Count == 0 && _lockTarget == _player.transform)
//        {
//            _lockTarget = _statue.transform;
//        }

//        // 석상을 추적 중에 플레이어가 발견됐다면,
//        if (_fov.visibleTargets.Count != 0 && _lockTarget == _statue.transform)
//        {
//            _lockTarget = _player.transform;
//        }

//        if (_lockTarget != null)
//        {
//            DestPos = _lockTarget.position;
//            float distance = (DestPos - transform.position).magnitude;

//            if (distance <= _attackRange)
//            {
//                nma.SetDestination(transform.position);
//                State = Define.State.Attack;
//                return;
//            }
//        }

//        float dist = (DestPos - transform.position).magnitude;
//        Vector3 dir = (DestPos - transform.position).normalized;
//        if (dist < 0.1f)
//        {
//            State = Define.State.Idle;
//            nma.SetDestination(transform.position);
//        }

//        else
//        {
//            nma.SetDestination(DestPos);
//            nma.speed = _stat.MoveSpeed;
//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
//        }
//    }

//    protected override void UpdateAttack()
//    {
//        // 최초로 LockTarget이 죽었는지 검사
//        if (_lockTarget == null)
//        {
//            State = Define.State.Idle;
//            nma.SetDestination(transform.position);
//            return;
//        }

//        // 석상을 공격 중에 플레이어가 발견됐다면,
//        if (_lockTarget == _statue.transform && _fov.visibleTargets.Count != 0)
//        {
//            //_lockTarget = _fov.visibleTargets.Dequeue();
//            State = Define.State.Moving;
//            return;
//        }

//        // 플레이어를 공격 중 일때, 플레이어가 사라지면 Statue를 추적하기 
//        if (_fov.visibleTargets.Count == 0 && _lockTarget == _player.transform)
//        {
//            _lockTarget = _statue.transform;
//            State = Define.State.Moving;
//            return;
//        }

//        if (_lockTarget != null)
//        {
//            DestPos = _lockTarget.position;
//            float distance = (DestPos - transform.position).magnitude;

//            if (distance > _attackRange)
//            {
//                nma.SetDestination(transform.position);
//                State = Define.State.Moving;
//                return;
//            }

//            Vector3 dir = (_lockTarget.position - transform.position).normalized;
//            Quaternion quaternion = Quaternion.LookRotation(dir);
//            transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, 20 * Time.deltaTime);
//        }
//    }

//    void OnHitEvent()
//    {
//        if (_lockTarget != null)
//        {
//            // 데미지 처리는 공격을 받는 대상이 하는게 훨씬 좋다. (각종 버프같은 것들 때문에)
//            Stat targetStat = _lockTarget.GetComponent<Stat>();

//            if (targetStat != null)
//                targetStat.OnAttacked(_stat);
//        }
//    }
//}
