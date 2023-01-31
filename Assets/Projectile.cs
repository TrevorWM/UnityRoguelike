using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 shootDirection;
    private float projectileSpeed;

    public void Setup(Vector3 shootDirection, float projectileSpeed, float projectileAliveTime)
    {
        this.shootDirection = shootDirection;
        this.projectileSpeed = projectileSpeed;
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
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
