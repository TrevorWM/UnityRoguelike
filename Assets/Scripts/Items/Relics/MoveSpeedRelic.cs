using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedRelic : Relic {

    private const string NAME = "Move Speed Relic";
    private const float BUFF_AMOUNT = 0.1f;
    public MoveSpeedRelic()
    {
        this.RelicName = NAME;
    }

    public override void ApplyRelicEffect(Stats targetStats, int stacks)
    {
        CharacterBaseSO baseStats = targetStats.BaseStats;

        if (targetStats != null)
        {
            targetStats.MoveSpeed = baseStats.MoveSpeed + (BUFF_AMOUNT * stacks);
        }
    }

}
