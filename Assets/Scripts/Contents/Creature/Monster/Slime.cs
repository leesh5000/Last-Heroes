using UnityEngine;
using System.Collections;

public class Slime : Creature
{
    public override void Init()
    {
        Stat = gameObject.GetOrAddComponent<MonsterStat>();

        //Animator animator = gameObject.GetComponent<Animator>();

        //animator.SetFloat("AttackSpeed", 10.0f);
    }
}
