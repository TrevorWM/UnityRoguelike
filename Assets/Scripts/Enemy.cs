using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] public float maxHealth = 10f;
    [SerializeField] private float currentHealth = 10f;

    [Header("Movement Values")]
    [SerializeField] public float moveSpeed = 5.0f;

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Took damage. Current health: " + currentHealth);

        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
