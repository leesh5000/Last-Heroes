using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : CreatureController
{
    public CharacterStat Stat { get; set; }

    Vector3 CameraForward { get { return Camera.main.transform.forward; } }
    Vector3 CameraRight { get { return Camera.main.transform.right; } }
    UI_Joystick ui_Joystick;
    Vector3 input;
    public Animator PlayerAnimator { get; set; }

    public override void Init()
    {
        WorldObjectType = Define.WorldObject.Chracter;

        gameObject.layer = (int)Define.Layer.Player;

        gameObject.tag = "Player";

        //Creature character = gameObject.GetComponent(Managers.Game.Player.name) as Creature;
        // 캐릭터 스텟 정보 가져오기
        Stat = gameObject.GetOrAddComponent<CharacterStat>();

        // NMA 가져오기
        nma = Util.GetOrAddComponent<NavMeshAgent>(gameObject);
        nma.avoidancePriority = 40;

        // 공격 사거리 설정
        _fov = gameObject.GetOrAddComponent<FieldOfView>();
        _fov.targetMask = (1 <<(int)Define.Layer.WaveMonster | 1<<(int)Define.Layer.Monster);
        _fov.ViewRadius = Stat.AttackRange;

        // 애니메이터 등록
        PlayerAnimator = GetComponent<Animator>();

        // HP바 가져오기
        if (gameObject.GetComponentInChildren<UI_HPBar>() == null)
            Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);



        #region 이벤트 등록
        //Managers.Input.KeyboardAction -= OnKeyboardEvent;
        //Managers.Input.KeyboardAction += OnKeyboardEvent;
        //Managers.Input.MouseAction -= OnMouseEvent;
        //Managers.Input.MouseAction += OnMouseEvent;
        Managers.Input.JoystickAcition -= OnJoystickEvent;
        Managers.Input.JoystickAcition += OnJoystickEvent;
        #endregion

        // 먼저 조이스틱이 없다면 만들어주기
        // joystick = GameObject.FindObjectOfType<UI_Joystick>();
        if (ui_Joystick == null)
        {
            GameObject ui_GameScene = GameObject.Find("UI_GameScene");
            ui_Joystick = Util.FindChildren<UI_Joystick>(ui_GameScene);
        }
    }

    protected override void UpdateIdle()
    {

    }

    protected override void UpdateMoving()
    {
        if (_lockTarget != null)
            _lockTarget = null;

        input.y = 0;
        Vector3 dir = input.normalized;
        
        transform.forward = Vector3.Slerp(transform.forward, dir, 0.15f);

        if (Physics.Raycast(transform.position, dir, 1.0f, _fov.targetMask))
            dir = Vector3.zero;

        transform.position += dir * Stat.MoveSpeed * Time.smoothDeltaTime;
    }

    protected override void UpdateAttack()
    {
        if (_lockTarget != null && _lockTarget.GetComponent<CreatureStat>().Hp <= 0)
        {
            _lockTarget = null;
            State = Define.State.Idle;
            return;
        }

        if (_lockTarget != null && _fov.visibleTargets.Count != 0)
        {
            Vector3 dir = (_lockTarget.position - transform.position).normalized;
            transform.forward = Vector3.Slerp(transform.forward, dir, 0.15f);
        }
    }

    void OnHitEvent()
    {
        if (_lockTarget != null)
        {
            CreatureStat targetStat = _lockTarget.gameObject.GetComponent<CreatureStat>();
            targetStat.OnAttacked(Stat);
        }
    }

    void OnJoystickEvent()
    {
        if (ui_Joystick.JoyDir != Vector3.zero)
        {
            //// 조이스틱을 움직였는데, 아이템 정보창이 떠있다면 닫아주기
            //if (Util.IsValid(Managers.UI.UI_ItemInfo))
            //{
            //    Managers.UI.UI_ItemInfo.GetComponent<UI_ItemInfo>().ExitItemInfo();
            //}

            float vAxis = ui_Joystick.JoyDir.y;
            float hAxis = ui_Joystick.JoyDir.x;
            input = CameraForward * vAxis + CameraRight * hAxis;

            if (State != Define.State.Moving)
            {
                State = Define.State.Moving;
                return;
            }
        }

        if (ui_Joystick.JoyDir == Vector3.zero && _fov.visibleTargets.Count != 0)
        {
            if (_lockTarget == null)
            {
                // 플레이어가 가장 가까운 적을 때리지 않는 것을 방지하기 위해서 큐에서 다 빼고 거리 계산하기
                if (_fov.visibleTargets.Count != 0)
                    _lockTarget = _fov.visibleTargets.Dequeue();
            }

            if (State != Define.State.Attack)
            {
                State = Define.State.Attack;
                return;
            }

            return;
        }

        if (ui_Joystick.JoyDir == Vector3.zero)
        {
            //if (State != Define.State.Wait && State != Define.State.Idle) State = Define.State.Wait;
            if (State != Define.State.Idle)
            {
                State = Define.State.Idle;
                return;
            }

            return;
        }
    }

    #region 다른입력
    void OnKeyboardEvent(Define.KeyboardEvent evt)
    {
        if (evt != Define.KeyboardEvent.None)
        {
            float vAxis = Input.GetAxis("Vertical");
            float hAxis = Input.GetAxis("Horizontal");
            input = CameraForward * vAxis + CameraRight * hAxis;
            if (State != Define.State.Moving) State = Define.State.Moving;
        }
        else
        {
            if (State != Define.State.Wait) State = Define.State.Wait;
        }
    }
    void OnMouseEvent(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.OnPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            LayerMask mask = LayerMask.GetMask("Floor");
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                DestPos = hit.point;
                // _destPos.y = transform.position.y;
                input = (DestPos - transform.position).normalized;
            }

            if (State != Define.State.Moving && State != Define.State.Idle) State = Define.State.Moving;
        }

        if (evt == Define.MouseEvent.ButtonDown)
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //LayerMask mask = LayerMask.GetMask("Floor");
            //RaycastHit hit;


            //if (Physics.Raycast(ray, out hit, 100.0f, mask))
            //{
            //    DestPos = hit.point;
            //    // _destPos.y = transform.position.y;
            //    input = (DestPos - transform.position).normalized;
            //}

            //if (State != Define.State.Moving) State = Define.State.Moving;
        }

        if (evt == Define.MouseEvent.ButtonUp)
        {

        }

        if (evt == Define.MouseEvent.None)
        {
            if (DestPos == Vector3.zero) return;
            float remainDist = (DestPos - transform.position).magnitude;
            if (remainDist < 0.05f)
            {
                if (State != Define.State.Wait && State != Define.State.Idle)
                    State = Define.State.Wait;
            }
        }
    }
    #endregion
}