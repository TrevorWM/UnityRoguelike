using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    [SerializeField] private CharacterStatsSO statSO;

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

    public Stats(CharacterStatsSO statSO)
    {
        MaxHealth = statSO.maxHealth;
        CurrentHealth = MaxHealth;

        MoveSpeed = statSO.moveSpeed;
        DodgeForce = statSO.dodgeForce;
        DodgeTime = statSO.dodgeTime;
    }
}
