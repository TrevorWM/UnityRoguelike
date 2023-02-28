using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Relic : MonoBehaviour, ICollectible
{
    public enum RelicEffectTypeEnum
    {
        Passive,
        OnAttack,
        OnTargetHit,
        OnTargetDeath,
        OnSelfHit,
    }

    private string relicName;
    private RelicEffectTypeEnum relicEffectType;

    public string RelicName { get => relicName; set => relicName = value; }
    public RelicEffectTypeEnum RelicEffectType { get => relicEffectType; set => relicEffectType = value; }

    public static event Action<Relic> OnRelicCollected;
    
    public abstract void ApplyRelicEffect(Stats targetStats, int stacks);

    public virtual void Collect()
    {
        Debug.LogFormat("You collected a {0}", RelicName);
        OnRelicCollected?.Invoke(this);

    }
}
