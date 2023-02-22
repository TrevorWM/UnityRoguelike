using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Relic
{
    private string relicName;
    public string RelicName { get => relicName; set => relicName = value; }

    public abstract void ApplyRelicEffect(GameObject target, int stacks);
    

}
