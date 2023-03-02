using UnityEngine.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AbilityWithProjectile : Ability
{
    [SerializeField] Projectile projectilePrefab;
    private ObjectPool<Projectile> projectilePool;

    public void Awake()
    {
        projectilePool = new ObjectPool<Projectile>(CreateProjectile, TakeProjectileFromPool, ReturnProjectileToPool);
    }
    protected Projectile CreateProjectile()
    {
        Projectile projectile = Instantiate(projectilePrefab);
        return projectile;
    } 

    protected void TakeProjectileFromPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);
        //GetShootDirection();
    }

    protected void ReturnProjectileToPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
    }
    /*
     * TODO: Figure this thing out again to be less dependent on other stuff.
     * 
    public void SetShootDirection(Vector2 targetPosition, Vector2 shootFromPosition)
    {

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        Vector2 lookDirection = (mousePosition - shootFromPosition).normalized;

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        shootFromPosition.rotation = Quaternion.Euler(0, 0, angle);

        GameObject projectile = Instantiate(projectilePrefab, shootPositionVector, shootPosition.rotation);
        projectile.GetComponent<Projectile>().Setup(lookDirection);
    }
    */
}
