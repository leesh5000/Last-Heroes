using UnityEngine;
using System.Collections;

public class Knight : Creature
{
    public PlayerInventory PlayerInven { get; set; }

    public override void Init()
    {
        Stat = gameObject.GetOrAddComponent<CharacterStat>();
        PlayerInven = gameObject.GetComponent<PlayerInventory>();

        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetFloat("AttackSpeed", 1.0f);
    }
}
