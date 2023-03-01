using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Relic : MonoBehaviour, ICollectible
{
    public static event Action<RelicSO> OnRelicCollected;

    [SerializeField] private RelicSO relicSO;
    private SpriteRenderer spriteRenderer;

    public void Collect()
    {
        Debug.LogFormat("You collected a {0}", relicSO.RelicName);
        OnRelicCollected?.Invoke(this.relicSO);
    }
    
    public RelicSO GetRelicSO()
    {
        return relicSO;
    }

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        spriteRenderer.sprite = relicSO.Sprite;
        spriteRenderer.material = relicSO.ShaderMaterial;

        
    }
}
