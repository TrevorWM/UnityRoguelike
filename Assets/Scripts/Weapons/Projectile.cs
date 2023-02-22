using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Projectile : MonoBehaviour, IDamager
{
    private Vector3 shootDirection;
    private float projectileSpeed;
    private float damage;
    private ObservableList<ProjectilePowerup> currentModifiers = new ObservableList<ProjectilePowerup>();

    public void Setup(Vector3 shootDirection, float projectileSpeed, float projectileAliveTime, float damage)
    {
        this.shootDirection = shootDirection;
        this.projectileSpeed = projectileSpeed;
        this.damage = damage;
        TestModifiers();
        Destroy(gameObject, projectileAliveTime);
    }

    private void Update()
    {
        transform.position += shootDirection * projectileSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable enemy = collision.GetComponent<IDamagable>();

        if (enemy != null)
        {
            DealDamageTo(enemy);
            Destroy(gameObject);
        } 
    }

    public void DealDamageTo(IDamagable target)
    {
        target.TakeDamage(damage);
    }

    public void AddNewModifier(ProjectilePowerup newModifier)
    {
        currentModifiers.Add(newModifier);
    }

    private void TestModifiers()
    {
        currentModifiers.Add(new BaseDamagePowerup(this, 5.0f));
    }
}
