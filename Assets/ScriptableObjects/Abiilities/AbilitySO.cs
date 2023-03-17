using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(fileName = "NewAbilitySO", menuName = "Ability")]
public class AbilitySO : ScriptableObject
{
    [Header("Ability Properties")]
    public string abilityName;
    public float projectileSpeed;
    public float projectileRange;
    public float projectileDamage;
    public Projectile projectilePrefab;
}
