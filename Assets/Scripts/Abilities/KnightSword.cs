using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSword : Ability
{
    [Header("Ability Properties")]
    private const string NAME = "Knight Sword";
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform shootPosition;
    private Stats entityStats;

    private Camera cam;

    public KnightSword()
    {
        this.AbilityName = NAME;
    }

    public override void StartAbility(Stats entityStats)
    {
        this.entityStats = entityStats;
        StartCoroutine("AttackTimer");
        Debug.Log("Starting Ability");
    }
    public override void StopAbility()
    {
        StopCoroutine("AttackTimer");
        Debug.Log("Stopping Ability");
    }
    private void Attack()
    {
        
        cam = Camera.main;

        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shootPositionVector = new Vector2(shootPosition.position.x, shootPosition.position.y);
        Vector2 lookDirection = (mousePosition - shootPositionVector).normalized;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        shootPosition.rotation = Quaternion.Euler(0, 0, angle);

        GameObject projectile = Instantiate(projectilePrefab, shootPositionVector, shootPosition.rotation);
        projectile.GetComponent<Projectile>().Setup(lookDirection, entityStats.ProjectileSpeed, entityStats.AttackRange, entityStats.AttackDamage);
        

    }
    IEnumerator Cooldown()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(1 / entityStats.AttacksPerSecond);
        }

    }

    private void CreateProjectile()
    {

    }
}



