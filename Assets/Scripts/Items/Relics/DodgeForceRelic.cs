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
    }

    public override void ApplyRelicEffect(Stats targetStats, int stacks)
    {
        CharacterBaseSO baseStats = targetStats.BaseStats;

        if (targetStats != null)
        {
            targetStats.DodgeForce = baseStats.DodgeForce * (Mathf.Pow(BUFF_AMOUNT, stacks));
        }
    }
}
