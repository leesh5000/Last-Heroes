using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkill : MonoBehaviour
{
    [SerializeField]
    private string _id;
    [SerializeField]
    private string _skill0;
    [SerializeField]
    private string _skill1;
    [SerializeField]
    private string _skill2;
    [SerializeField]
    private string _skill3;
    [SerializeField]
    private string _skill4;
    [SerializeField]
    private string _skill5;

    public string Id { get { return _id; } set { _id = value; } }
    public string Skill0 { get { return _skill0; } set { _skill0 = value; } }
    public string Skill1 { get { return _skill1; } set { _skill1 = value; } }
    public string Skill2 { get { return _skill2; } set { _skill2 = value; } }
    public string Skill3 { get { return _skill3; } set { _skill3 = value; } }
    public string Skill4 { get { return _skill4; } set { _skill4 = value; } }
    public string Skill5 { get { return _skill5; } set { _skill5 = value; } }

    void Awake()
    {
        SetSkill(Define.WorldObject.Chracter, gameObject.name);
    }

    public void SetSkill(Define.WorldObject type, string id)
    {
        Dictionary<string, ContentsData.CharacterSkill> skillDict = Managers.Data.CharacterSkillDict;

        ContentsData.CharacterSkill skill = skillDict[id];

        Skill0 = skill.Skill0;
        Skill1 = skill.Skill1;
        Skill2 = skill.Skill2;
        Skill3 = skill.Skill3;
        Skill4 = skill.Skill4;
        Skill5 = skill.Skill5;
    }
}
