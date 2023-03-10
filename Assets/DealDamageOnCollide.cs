using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageOnCollide : MonoBehaviour, IDamager
{
    [SerializeField] private Enemy enemy;
    private const int PLAYER_LAYER = 7;

    public void DealDamageTo(IDamagable target)
    {
        target.TakeDamage(enemy.damage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.layer == PLAYER_LAYER)
        {
            IDamagable target = collision.gameObject.GetComponent<IDamagable>();
            DealDamageTo(target);
        }
        
    }
}
