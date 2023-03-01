using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RelicSO;

[CreateAssetMenu(menuName ="Data/CharacterStats")]
public class CharacterBaseSO : ScriptableObject
{
    [Header("Default Stat Values")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dodgeForce;
    [SerializeField] private float dodgeTime;
    [SerializeField] private float attacksPerSecond;
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackRange;
    [SerializeField] private float projectileSpeed;
 
    [Header("Visual Information")]
    [SerializeField] private Sprite sprite;

    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float DodgeForce { get => dodgeForce; set => dodgeForce = value; }
    public float DodgeTime { get => dodgeTime; set => dodgeTime = value; }
    public float AttacksPerSecond { get => attacksPerSecond; set => attacksPerSecond = value; }
    public float AttackDamage { get => attackDamage; set => attackDamage = value; }
    public float AttackRange { get => attackRange; set => attackRange = value; }
    public float ProjectileSpeed { get => projectileSpeed; set => projectileSpeed = value; }
    public Sprite Sprite { get => sprite; set => sprite = value; }
}