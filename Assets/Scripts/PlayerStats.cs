using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private CharacterStatsSO playerStats;

    private float maxHealth;
    private float currentHealth;

    private float moveSpeed;

    private float dodgeForce;
    private float dodgeTime;

    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float DodgeForce { get => dodgeForce; set => dodgeForce = value; }
    public float DodgeTime { get => dodgeTime; set => dodgeTime = value; }

    private void Awake()
    {
        MaxHealth = playerStats.maxHealth;
        CurrentHealth = MaxHealth;

        MoveSpeed = playerStats.moveSpeed;
        DodgeForce = playerStats.dodgeForce;
        DodgeTime = playerStats.dodgeTime;
    }

    public float AdditiveIncrease(float stat, float amount)
    {
        return stat += amount;
    }

    public float MultiplicativeIncrease(float stat, float amount)
    {
        return stat *= amount;
    }

}
