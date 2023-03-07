using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAbilitySO", menuName = "Ability")]
public class AbilitySO : ScriptableObject
{
    [Header("Ability Properties")]
    [SerializeField] private string abilityName;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileRange;
    [SerializeField] private float projectileDamage;
    [SerializeField] private Projectile projectilePrefab;

    public string AbilityName { get => abilityName; set => abilityName = value; }
    public float ProjectileSpeed { get => projectileSpeed; set => projectileSpeed = value; }
    public float ProjectileRange { get => projectileRange; set => projectileRange = value; }
    public float ProjectileDamage { get => projectileDamage; set => projectileDamage = value; }
    public Projectile ProjectilePrefab { get => projectilePrefab; set => projectilePrefab = value; }
}
