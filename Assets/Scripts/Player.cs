using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] public float maxHealth = 10f;
    [SerializeField] private float currentHealth = 10f;

    [Header("Movement Values")]
    [SerializeField] public float moveSpeed = 5.0f;

    [Header("Dodge Values")]
    [SerializeField] public float dodgeForce = 1.05f;
    [SerializeField] public float dodgeTime = 0.3f;

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