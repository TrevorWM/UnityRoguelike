using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectilePowerup
{
    protected IDamager projectileToModify;

    public ProjectilePowerup(IDamager projectile)
    {
        this.projectileToModify = projectile;
    }

    protected abstract void ModifyProjectile();
   
    
    public void Apply(IDamager projectile)
    {
        if (projectileToModify != null)
        {
            projectileToModify = projectile;
            ModifyProjectile();
        }
    }

    
}
