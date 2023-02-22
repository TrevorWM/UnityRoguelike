using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable {
    [Header("Health")]
    [SerializeField] public float maxHealth = 10f;
    [SerializeField] private float currentHealth = 10f;

    [Header("Movement Values")]
    [SerializeField] public float moveSpeed = 5.0f;


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.LogFormat("Took {0} damage", damage);
        DestroyIfDead();
    }

    public void TakeDamageOverSeconds(float damage, float seconds)
    {
        throw new System.NotImplementedException();
    }

    private IEnumerator DamageOverSeconds(float damage, float seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            yield return new WaitForSeconds(1);
            TakeDamage(damage);
        }
    }

    private bool IsDead()
    {
        return currentHealth < 0;
    }

    private void DestroyIfDead()
    {
        if (IsDead()) { Destroy(gameObject); }
    }
}