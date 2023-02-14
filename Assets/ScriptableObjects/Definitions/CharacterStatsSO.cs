using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/CharacterStats")]
public class CharacterStatsSO : ScriptableObject
{
    [SerializeField] public float maxHealth;
    [SerializeField] public float moveSpeed;
    [SerializeField] public float dodgeForce;
    [SerializeField] public float dodgeTime;
    [SerializeField] public float attacksPerSecond;
    [SerializeField] public float attackDamage;
    [SerializeField] public float projectileSpeed;
    [SerializeField] public float projectileLifeTime;
    
    [SerializeField] public Sprite sprite;
}
