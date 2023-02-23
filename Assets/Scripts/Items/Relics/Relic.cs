using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public abstract class Relic : MonoBehaviour, ICollectible
{
    private string relicName;
    public string RelicName { get => relicName; set => relicName = value; }

    public static event Action<Relic> OnRelicCollected;
    
    public abstract void ApplyRelicEffect(Stats targetStats, int stacks);

    public virtual void Collect()
    {
        Debug.LogFormat("You collected a {0}", RelicName);
        OnRelicCollected?.Invoke(this);

    }
}
