using UnityEngine.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AbilityWithProjectile : MonoBehaviour, IAbility
{
    [SerializeField] AbilitySO abilitySO;
    protected ObjectPool<Projectile> projectilePool;

    [SerializeField] protected ShootPositionHelper shootPositionHelper;
    private Stats entityStats;
    WaitForSeconds projectileTimeout = new WaitForSeconds(10);
    
    public void Awake()
    {
        projectilePool = new ObjectPool<Projectile>(CreateProjectile,TakeProjectileFromPool,ReturnProjectileToPool, DestroyPoolObject, maxSize: 100);
    }

    protected Projectile CreateProjectile()
    {
        Projectile projectile = Instantiate(abilitySO.projectilePrefab);
        
        return projectile;
    } 

    protected void TakeProjectileFromPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);

    }

    protected void ReturnProjectileToPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);

    }

    protected void DestroyPoolObject(Projectile projectile)
    {
        Destroy(projectile.gameObject);
    }
    
    public void StartAbility(Stats entityStats)
    {
        this.entityStats = entityStats;
        StartCoroutine("IAbility.Cooldown");
    }
    public void StopAbility()
    {
        StopCoroutine("IAbility.Cooldown");
    }
    private void Attack()
    {
        Projectile projectile = projectilePool.Get();
        projectile.transform.position = shootPositionHelper.GetShootPosition();
        projectile.transform.rotation = shootPositionHelper.GetShootRotation();
        Vector2 shootDirection = shootPositionHelper.GetShootDirection();

        projectile.FireProjectile(shootDirection, abilitySO.projectileSpeed, abilitySO.projectileRange, abilitySO.projectileDamage);
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
        yield return projectileTimeout;
        projectilePool.Release(projectile);
    }
}