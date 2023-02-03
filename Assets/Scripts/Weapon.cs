using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [Header("Weapon Properties")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform shootPosition;
    [SerializeField] private float attacksPerSecond = 1.0f;
    [SerializeField] private float attackDamage = 1.0f;
    [SerializeField] private float projectileSpeed = 10.0f;
    [SerializeField] private float projectileAliveTime = 0.5f;

    private Camera cam;

    private void FireProjectile()
    {
        cam = Camera.main;

        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shootPositionVector = new Vector2(shootPosition.position.x, shootPosition.position.y);
        Vector2 lookDirection = (mousePosition - shootPositionVector).normalized;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        shootPosition.rotation = Quaternion.Euler(0, 0, angle);

        GameObject projectile = Instantiate(projectilePrefab, shootPositionVector, shootPosition.rotation);
        projectile.GetComponent<Projectile>().Setup(lookDirection, projectileSpeed, projectileAliveTime, attackDamage);

    }

    public void StartAttacking()
    {
            StartCoroutine("Attack");
    }


    IEnumerator Attack()
    {
        while (true)
        {
            FireProjectile();
            yield return new WaitForSeconds(1 / attacksPerSecond);
        }

    }

    public void StopAttacking()
    {
        StopCoroutine("Attack");
    }
}



