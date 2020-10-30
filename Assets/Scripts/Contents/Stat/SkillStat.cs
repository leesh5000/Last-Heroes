using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillStat : MonoBehaviour
{
    [SerializeField]
    private int _level;
    [SerializeField]
    private string _require;
    [SerializeField]
    private string _type;
    [SerializeField]
    private int _cost;
    [SerializeField]
    private string _message;

    public int Level { get { return _level; } set { _level = value; } }
    public string Require { get { return _require; } set { _require = value; } }
    public string Type { get { return _type; } set { _type = value; } }
    public int Cost { get { return _cost; } set { _cost = value; } }
    public string Message { get { return _message; } set { _message = value; } }

    public void Start()
    {
        Init();
    }

    public void Init()
    {
        SetSkill(gameObject.name, 0);
    }

    public void SetSkill(string id, int level)
    {
        Level = level;

        string newId = id + $"  -  level {level}";

        Dictionary<string, ContentsData.SkillStat> statDict = Managers.Data.SkillStatDict;
        ContentsData.SkillStat stat = statDict[newId];

        Require = stat.Require;
        Type = stat.Type;
        Cost = stat.Cost;
        Message = stat.Message;
    }
}
