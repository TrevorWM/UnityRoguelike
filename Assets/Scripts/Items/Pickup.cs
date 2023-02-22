using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Collider2D objectCollider2D;
    public event EventHandler OnPickupObject;

    private void Awake()
    {
        objectCollider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            Debug.Log("Picked up Relic!");
            OnPickupObject?.Invoke(this, EventArgs.Empty);
            Destroy(this.gameObject);
        }

    }
}
