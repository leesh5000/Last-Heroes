using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Data.Contents는 실제로 사용되지는 않고, Json에서 어떻게 파일포맷형식을 불러올지를 지정해준다고 생각하면 된다.

namespace ContentsData
{
    [Serializable]
    public class ChracterStat
    {
        public string id;

        public int level;
        public int totalExp;

        public int maxHp;
        public int attack;
        public int defense;

        public float attackSpeed;
        public float moveSpeed;

        public int attackRange;
        public int viewRadius;
        public int viewAngle;
    }

    [Serializable]
    public class WaveMonsterStat
    {
        public string id;

        public int level;

        public int maxHp;
        public int attack;
        public int defense;

        public float attackSpeed;
        public float moveSpeed;

        public int attackRange;
        public int viewRadius;
        public int viewAngle;
    }

    [Serializable]
    public class ItemStat
    {

    }

    [Serializable]
    public class ChracterStatDataLoader : ILoader<string, ChracterStat>
    {
        public List<ChracterStat> stats = new List<ChracterStat>();

        public Dictionary<string, ChracterStat> ConvertDict()
        {
            Dictionary<string, ChracterStat> dict = new Dictionary<string, ChracterStat>();

            foreach (ChracterStat stat in stats)
                dict.Add(stat.id, stat);

            return dict;
        }
    }

    [Serializable]
    public class WaveMonsterStatDataLoader : ILoader<string, WaveMonsterStat>
    {
        public List<WaveMonsterStat> stats = new List<WaveMonsterStat>();

        public Dictionary<string, WaveMonsterStat> ConvertDict()
        {
            Dictionary<string, WaveMonsterStat> dict = new Dictionary<string, WaveMonsterStat>();

            foreach (WaveMonsterStat stat in stats)
                dict.Add(stat.id, stat);

            return dict;
        }
    }
}

