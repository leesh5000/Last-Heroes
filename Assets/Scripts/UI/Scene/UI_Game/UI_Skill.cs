using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Skill : UI_SceneBase
{
    enum Transforms
    {
        SkillSlot0,
        SkillSlot1,
        SkillSlot2,
        SkillSlot3,
        SkillSlot4,
        SkillSlot5,
    }

    Transform SkillSlot0;
    Transform SkillSlot1;
    Transform SkillSlot2;
    Transform SkillSlot3;
    Transform SkillSlot4;
    Transform SkillSlot5;

    public override void Init()
    {
        base.Init();

        Managers.UI.UI_Skill = gameObject;

        Bind<Transform>(typeof(Transforms));
        SkillSlot0 = Get<Transform>((int)Transforms.SkillSlot0);
        SkillSlot1 = Get<Transform>((int)Transforms.SkillSlot1);
        SkillSlot2 = Get<Transform>((int)Transforms.SkillSlot2);
        SkillSlot3 = Get<Transform>((int)Transforms.SkillSlot3);
        SkillSlot4 = Get<Transform>((int)Transforms.SkillSlot4);
        SkillSlot5 = Get<Transform>((int)Transforms.SkillSlot5);

        CharacterSkill skills = Managers.Game.Player.GetComponent<PlayerController>().Skill;
        GameObject skill0 = Managers.Resource.Instantiate($"Prefabs/Skill/{skills.Skill0}");
        skill0.transform.SetParent(SkillSlot0);
        skill0.transform.localPosition = Vector2.zero;
    }
}
