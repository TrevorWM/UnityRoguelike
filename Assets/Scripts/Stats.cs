using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    

    [SerializeField] CharacterBaseSO baseStats;
    private float maxHealth;
    private float currentHealth;

    private float moveSpeed;

    private float dodgeForce;
    private float dodgeTime;

    private float attacksPerSecond;
    private float attackDamage;
    private float attackRange;
    private float projectileSpeed;


    private void Awake()
    {
        maxHealth = BaseStats.MaxHealth;
        currentHealth = maxHealth;
        moveSpeed = BaseStats.MoveSpeed;
        dodgeForce = BaseStats.DodgeForce;
        dodgeTime = BaseStats.DodgeTime;
        attacksPerSecond = BaseStats.AttacksPerSecond;
        attackDamage = BaseStats.AttackDamage;
        attackRange = BaseStats.AttackRange;
        ProjectileSpeed = BaseStats.ProjectileSpeed;
    }

    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float DodgeForce { get => dodgeForce; set => dodgeForce = value; }
    public float DodgeTime { get => dodgeTime; set => dodgeTime = value; }
    public float AttacksPerSecond { get => attacksPerSecond; set => attacksPerSecond = value; }
    public float AttackDamage { get => attackDamage; set => attackDamage = value; }
    public float AttackRange { get => attackRange; set => attackRange = value; }
    public float ProjectileSpeed { get => projectileSpeed; set => projectileSpeed = value; }
    public CharacterBaseSO BaseStats { get => baseStats; set => baseStats = value; }
}
