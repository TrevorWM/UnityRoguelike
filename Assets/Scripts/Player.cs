using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private GameplayInput gameplayInput;

    [SerializeField] private StatsSO playerStats;
    [SerializeField] private Weapon weaponScript;

    [Header("Health")]
    [SerializeField] public float maxHealth = 10f;
    [SerializeField] private float currentHealth = 10f;

    [Header("Movement Values")]
    [SerializeField] public float moveSpeed = 5.0f;

    [Header("Dodge Values")]
    [SerializeField] public float dodgeForce = 1.05f;
    [SerializeField] public float dodgeTime = 0.3f;

    private Rigidbody2D playerRigidbody;
    private bool isDodging = false;
    private Vector2 inputVector = Vector2.zero;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        gameplayInput = GetComponent<GameplayInput>();


        gameplayInput.OnDodgeAction += GameplayInput_OnDodgeAction;
        gameplayInput.OnAttackStart += GameplayInput_OnAttackStart;
        gameplayInput.OnAttackEnd += GameplayInput_OnAttackEnd;
    }

    private void GameplayInput_OnAttackEnd(object sender, System.EventArgs e)
    {
        weaponScript.StartAttacking();
    }

    private void GameplayInput_OnAttackStart(object sender, System.EventArgs e)
    {
        weaponScript.StopAttacking();
    }

    private void Update()
    {
        inputVector = gameplayInput.GetMovementVectorNormalized();
        HandleMoveCharacter();
        HandleFaceDirection();
    }

    private void HandleMoveCharacter()
    {
        if (!isDodging)
        {
            playerRigidbody.velocity = inputVector * moveSpeed;
        }
        
    }

    private void HandleFaceDirection()
    {
        if (playerRigidbody.velocity.x > 0)
        {
            playerRigidbody.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        }
        else if (playerRigidbody.velocity.x < 0)
        {
            playerRigidbody.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }

    private void GameplayInput_OnDodgeAction(object sender, System.EventArgs e)
    {
        if (!isDodging)
        {
            isDodging = true;
            StartCoroutine("DodgeCooldown");
            playerRigidbody.AddForce(playerRigidbody.velocity * dodgeForce, ForceMode2D.Impulse);
        }
    }

    IEnumerator DodgeCooldown()
    {
        yield return new WaitForSeconds(dodgeTime);
        playerRigidbody.velocity = inputVector * moveSpeed;
        isDodging = false;

    }


    public bool IsRunning()
    {
        return inputVector != Vector2.zero;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Took damage. Current health: " + currentHealth);

        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}