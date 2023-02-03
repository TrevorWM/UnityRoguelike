using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/Stats")]
public class StatsSO : ScriptableObject
{
    [SerializeField] private float health;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dodgeForce;
    [SerializeField] private float dodgeTime;
    [SerializeField] private float attacksPerSecond;
    [SerializeField] private float attackDamage;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileLifeTime;
}
