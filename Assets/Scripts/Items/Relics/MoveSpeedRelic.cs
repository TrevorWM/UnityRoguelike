using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedRelic : Relic {

    private const string NAME = "Move Speed Relic";
    private const float BUFF_AMOUNT = 0.1f;
    
    /*public MoveSpeedRelic()
    {
        this.RelicName = NAME;
        this.RelicEffectType = RelicEffectTypeEnum.Passive;
    }
    
    public override void ApplyRelicEffect(Stats targetStats, int stacks)
    {
        if (targetStats != null)
        {
            targetStats.MoveSpeed = targetStats.BaseStats.MoveSpeed + (BUFF_AMOUNT * stacks);
        }
    }
    */
}
