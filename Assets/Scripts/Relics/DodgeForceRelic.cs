using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DodgeForceRelic : Relic 
{
    public DodgeForceRelic()
    {
        this.RelicName = "Dodge Force Relic";
    }
    public override void ApplyRelicEffect(GameObject target, int stacks)
    {
        Debug.LogFormat("Applying {0} stacks of {1} to {2}", stacks, RelicName, target);
    }
}
