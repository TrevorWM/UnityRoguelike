using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Relic : MonoBehaviour, ICollectible
{
    [SerializeField] private RelicSO relicSO;
    private SpriteRenderer spriteRenderer;

    public void Collect()
    {
        relicSO.Collect();
    }

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = relicSO.Sprite;
        spriteRenderer.material = relicSO.ShaderMaterial;
    }
}
