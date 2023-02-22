using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void TakeDamage(float damage);
    void TakeDamageOverSeconds(float damage, float seconds);

}