using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Data.Contents는 실제로 사용되지는 않고, Json에서 어떻게 파일포맷형식을 불러올지를 지정해준다고 생각하면 된다.

namespace ContentsData
{
    [Serializable]
    public class ItemStat
    {
        public string ID;
        public string Class;
        public int Price;
        public int HP;
        public int Attack;
        public int Defense;
        public float MoveSpeed;
    }

    [Serializable]
    public class CharacterStat
    {
        public string ID;
        public string SubName;
        public string Description;
        public float AttackRange;
        public float AttackSpeed;
        public float MoveSpeed;
        public int STR;
        public int AGI;
        public int INT;
        public int Level;
        public int EXP;
        public int HP;
        public int MP;
        public int Attack;
        public int Defense;
    }

    [Serializable]
    public class MonsterStat
    {
        public string ID;
        public int HP;
        public int MP;
        public float AttackRange;
        public float AttackSpeed;
        public float MoveSpeed;
        public int Attack;
        public int Defense;
        public int EXP;
        public int Gold;
    }

    [Serializable]
    public class CharacterSkill
    {
        public string ID;
        public string Skill0;
        public string Skill1;
        public string Skill2;
        public string Skill3;
        public string Skill4;
        public string Skill5;
    }

    [Serializable]
    public class SkillStat
    {
        public string ID;
        public string Require;
        public string Type;
        public int Cost;
        public string Message;
    }

    [Serializable]
    public class CharacterSkillData : ILoader<string, CharacterSkill>
    {
        public List<CharacterSkill> skills = new List<CharacterSkill>();

        public Dictionary<string, CharacterSkill> ConvertDict()
        {
            Dictionary<string, CharacterSkill> dict = new Dictionary<string, CharacterSkill>();

            foreach (CharacterSkill skill in skills)
                dict.Add(skill.ID, skill);

            return dict;
        }
    }

    [Serializable]
    public class SkillStatData : ILoader<string, SkillStat>
    {
        public List<SkillStat> stats = new List<SkillStat>();

        public Dictionary<string, SkillStat> ConvertDict()
        {
            Dictionary<string, SkillStat> dict = new Dictionary<string, SkillStat>();

            foreach (SkillStat stat in stats)
                dict.Add(stat.ID, stat);

            return dict;
        }
    }

    [Serializable]
    public class ItemStatData : ILoader<string, ItemStat>
    {
        public List<ItemStat> stats = new List<ItemStat>();

        public Dictionary<string, ItemStat> ConvertDict()
        {
            Dictionary<string, ItemStat> dict = new Dictionary<string, ItemStat>();

            foreach (ItemStat stat in stats)
                dict.Add(stat.ID, stat);

            return dict;
        }
    }

    [Serializable]
    public class CharacterStatData : ILoader<string, CharacterStat>
    {
        public List<CharacterStat> stats = new List<CharacterStat>();

        public Dictionary<string, CharacterStat> ConvertDict()
        {
            Dictionary<string, CharacterStat> dict = new Dictionary<string, CharacterStat>();

            foreach (CharacterStat stat in stats)
                dict.Add(stat.ID, stat);

            return dict;
        }
    }

    [Serializable]
    public class MonsterStatData : ILoader<string, MonsterStat>
    {
        public List<MonsterStat> stats = new List<MonsterStat>();

        public Dictionary<string, MonsterStat> ConvertDict()
        {
            Dictionary<string, MonsterStat> dict = new Dictionary<string, MonsterStat>();

            foreach (MonsterStat stat in stats)
                dict.Add(stat.ID, stat);

            return dict;
        }
    }
}

