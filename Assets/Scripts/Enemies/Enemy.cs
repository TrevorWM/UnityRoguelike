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

    public float damage = 2f;

    public void Awake()
    {
        int layer = LayerMask.NameToLayer("Enemies");
        this.gameObject.layer = layer;
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        Debug.LogFormat("Took {0} damage", damageToTake);
        DestroyIfDead();
    }

    public void TakeDamageOverSeconds(float damageToTake, float seconds)
    {
        throw new System.NotImplementedException();
    }

    private IEnumerator DamageOverSeconds(float damageToTake, float seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            yield return new WaitForSeconds(1);
            TakeDamage(damage);
        }
    }

    private bool IsDead()
    {
        return currentHealth < 1;
    }

    private void DestroyIfDead()
    {
        if (IsDead()) Destroy(gameObject); 
    }
}