using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePowerup : MonoBehaviour
{

    private Collider2D powerupCollider;
    [SerializeField] protected float powerupValue;

    public abstract void Apply(GameObject target);


    private void Awake()
    {
        powerupCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            Apply(other.gameObject);
        }

    }
}
