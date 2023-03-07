using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSword : AbilityWithProjectile, IAbility
{
    [Header("Ability Properties")]
    [SerializeField] private const string NAME = "Knight Sword";
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileRange;
    [SerializeField] private float projectileDamage;
    
    private Stats entityStats;

    public void StartAbility(Stats entityStats)
    {
        this.entityStats = entityStats;
        StartCoroutine("IAbility.Cooldown");
        Debug.Log("Starting Ability");
    }
    public void StopAbility()
    {
        StopCoroutine("IAbility.Cooldown");
        Debug.Log("Stopping Ability");
    }
    private void Attack()
    {
        Projectile projectile = projectilePool.Get();
        Vector2 shootDirection = shootPositionHelper.GetShootDirection();

        projectile.FireProjectile(shootDirection, projectileSpeed, projectileRange, projectileDamage);
        StartCoroutine(ReleaseObjectAfterTime(projectile));
    }

    IEnumerator IAbility.Cooldown()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(1 / entityStats.AttacksPerSecond);
        }
    }

    private IEnumerator ReleaseObjectAfterTime(Projectile projectile)
    {
        yield return new WaitForSeconds(projectileRange);
        projectilePool.Release(projectile);
        
    }
}



