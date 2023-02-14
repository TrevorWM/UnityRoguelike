using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 shootDirection;
    private float projectileSpeed;
    private float damage;

    public void Setup(Vector3 shootDirection, float projectileSpeed, float projectileAliveTime, float damage)
    {
        this.shootDirection = shootDirection;
        this.projectileSpeed = projectileSpeed;
        this.damage = damage;
        Destroy(gameObject, projectileAliveTime);
    }

    private void Update()
    {
        transform.position += shootDirection * projectileSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        } 
    }
}
