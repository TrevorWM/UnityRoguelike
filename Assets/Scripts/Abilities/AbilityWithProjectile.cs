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
    public void Awake()
    {
        projectilePool = new ObjectPool<Projectile>(CreateProjectile,TakeProjectileFromPool,ReturnProjectileToPool, DestroyPoolObject, maxSize: 100);
    }

    protected Projectile CreateProjectile()
    {
        Projectile projectile = Instantiate(abilitySO.ProjectilePrefab);
        
        return projectile;
    } 

    protected void TakeProjectileFromPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);
        projectile.transform.position = shootPositionHelper.GetShootPosition();
        projectile.transform.rotation = shootPositionHelper.GetShootRotation();
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

       projectile.FireProjectile(shootDirection, abilitySO.ProjectileSpeed, abilitySO.ProjectileRange, abilitySO.ProjectileDamage);
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
        yield return new WaitForSeconds(abilitySO.ProjectileRange);
        projectilePool.Release(projectile);

    }
}