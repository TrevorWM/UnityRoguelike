using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamageRelic : Relic
{
    private const string NAME = "Attack Damage Relic";
    private const float BUFF_AMOUNT = 1.0f;
    /*
    public AttackDamageRelic()
    {
        this.RelicName = NAME;
        this.RelicEffectType = RelicEffectTypeEnum.Passive;
    }

    public override void ApplyRelicEffect(Stats targetStats, int stacks)
    {
        if (targetStats != null)
        {
            targetStats.AttackDamage = targetStats.BaseStats.AttackDamage + (BUFF_AMOUNT * stacks);
        }
    }
    */
}
