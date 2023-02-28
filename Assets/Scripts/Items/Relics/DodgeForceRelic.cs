using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class DodgeForceRelic : Relic 
{
    private const string NAME = "Dodge Force Relic";
    private const float BUFF_AMOUNT = 1.05f;
    public DodgeForceRelic()
    {
        this.RelicName = NAME;
        this.RelicEffectType = RelicEffectTypeEnum.Passive;
    }

    public override void ApplyRelicEffect(Stats targetStats, int stacks)
    {
        if (targetStats != null)
        {
            targetStats.DodgeForce = targetStats.BaseStats.DodgeForce * (Mathf.Pow(BUFF_AMOUNT, stacks));
        }
    }
}
