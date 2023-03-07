using UnityEngine.Pool;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour, IAbility
{
    private string abilityName;
    public string AbilityName { get => abilityName; set => abilityName = value; }
  
    public IEnumerator Cooldown()
    {
        throw new NotImplementedException();
    }

    public virtual void StartAbility(Stats entityStats)
    {
        throw new System.NotImplementedException();
    }

    public virtual void StopAbility()
    {
        throw new System.NotImplementedException();
    }
}
