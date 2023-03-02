using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Projectile : MonoBehaviour, IDamager
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
        IDamagable target = collision.GetComponent<IDamagable>();

        if (target != null)
        {
            DealDamageTo(target);
            Destroy(gameObject);
        } 
    }

    public void DealDamageTo(IDamagable target)
    {
        target.TakeDamage(damage);
    }
}
