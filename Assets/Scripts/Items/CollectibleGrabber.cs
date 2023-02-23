using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectibleGrabber : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectible collectibleObject = collision.GetComponent<ICollectible>();

        if (collectibleObject != null)
        {
            collectibleObject.Collect();
        }

    }
}
