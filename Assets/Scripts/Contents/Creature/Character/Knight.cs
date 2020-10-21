using UnityEngine;
using System.Collections;

public class Knight : Creature
{
    public override void Init()
    {
        Stat = gameObject.GetOrAddComponent<CharacterStat>();

        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetFloat("AttackSpeed", 1.0f);
    }
}
