using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Projectile : MonoBehaviour, IDamager
{
    private const int PLAYER_LAYER = 7;
    private Vector3 shootDirection;
    private float projectileSpeed;
    private float damage;
    private float aliveTime;

    
    public void FireProjectile(Vector2 shootDirection, float projectileSpeed, float projectileAliveTime, float damage)
    {
        this.shootDirection = shootDirection;
        this.projectileSpeed = projectileSpeed;
        this.damage = damage;
        this.aliveTime = projectileAliveTime;
    }

    private void Update()
    {
        transform.position += shootDirection * projectileSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.layer != PLAYER_LAYER)
        {
            IDamagable target = collision.GetComponent<IDamagable>();

            DealDamageTo(target);
            gameObject.SetActive(false);
        } 
    }

    public void DealDamageTo(IDamagable target)
    {
        target.TakeDamage(damage);
    }
}