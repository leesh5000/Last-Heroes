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
        public int Gold;
        public int HP;
        public int Attack;
        public int Defense;
        public float MoveSpeed;
    }

    [Serializable]
    public class ChracterStat
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
    public class ItemStatDataLoader : ILoader<string, ItemStat>
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
    public class ChracterStatDataLoader : ILoader<string, ChracterStat>
    {
        public List<ChracterStat> stats = new List<ChracterStat>();

        public Dictionary<string, ChracterStat> ConvertDict()
        {
            Dictionary<string, ChracterStat> dict = new Dictionary<string, ChracterStat>();

            foreach (ChracterStat stat in stats)
                dict.Add(stat.ID, stat);

            return dict;
        }
    }

    [Serializable]
    public class MonsterStatDataLoader : ILoader<string, MonsterStat>
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

