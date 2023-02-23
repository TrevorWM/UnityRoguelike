using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDamagePowerup : ProjectilePowerup
{
    [SerializeField] private float baseDamageIncrease;

    public BaseDamagePowerup(IDamager modifiedDamager, float baseDamageAmount) : base(modifiedDamager)
    {
        this.baseDamageIncrease = baseDamageAmount;
    }

    protected override void ModifyProjectile()
    {
        
    }

}
