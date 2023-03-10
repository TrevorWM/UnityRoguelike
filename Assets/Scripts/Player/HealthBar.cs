using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarImage;

    public void UpdateHealthBarImage(float maxHealth, float currentHealth)
    {
        healthBarImage.fillAmount = currentHealth / maxHealth;
    }

    private void Awake()
    {
        healthBarImage.fillAmount = 1;
    }

    private void OnEnable()
    {
        Player.OnPlayerDamaged += Player_OnPlayerDamaged;
    }

    private void OnDisable()
    {
        Player.OnPlayerDamaged -= Player_OnPlayerDamaged;
    }


    private void Player_OnPlayerDamaged(float maxHealth, float currentHealth)
    {
        UpdateHealthBarImage(maxHealth, currentHealth);
    }
}
