using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public Sprite Sprite { get { return sprite; } }

    public float MaxHealth { get => maxHealth; }
    public float MoveSpeed { get => moveSpeed; }
    public float DodgeForce { get => dodgeForce; }
    public float DodgeTime { get => dodgeTime; }
    public float AttacksPerSecond { get => attacksPerSecond; }
    public float AttackDamage { get => attackDamage; }
    public float AttackRange { get => attackRange; }
    public float ProjectileSpeed { get => projectileSpeed; }
}
