using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    void StartAbility(Stats entityStats);
    void StopAbility();
    IEnumerator Cooldown();
}
