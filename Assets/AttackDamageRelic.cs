using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamageRelic : Relic
{
    private const string NAME = "Dodge Force Relic";
    private const float BUFF_AMOUNT = 1.0f;

    public AttackDamageRelic()
    {
        this.RelicName = NAME;
    }

    public override void ApplyRelicEffect(Stats targetStats, int stacks)
    {
        CharacterBaseSO baseStats = targetStats.BaseStats;

        if (targetStats != null)
        {
            Debug.LogFormat("Adding effects of {1} stacks to {0}", targetStats, stacks);
            targetStats.AttackDamage = baseStats.AttackDamage + (BUFF_AMOUNT * stacks);
        }
    }
}
