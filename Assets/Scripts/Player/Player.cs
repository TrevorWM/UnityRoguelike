using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private GameplayInput gameplayInput;

    [SerializeField] private Weapon weaponScript;
    [SerializeField] private PlayerStats playerStats;
    
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

    private void OnDestroy()
    {
        gameplayInput.OnDodgeAction -= GameplayInput_OnDodgeAction;
        gameplayInput.OnAttackStart -= GameplayInput_OnAttackStart;
        gameplayInput.OnAttackEnd -= GameplayInput_OnAttackEnd;
    }

    private void GameplayInput_OnAttackEnd(object sender, System.EventArgs e)
    {
        weaponScript.StartAttacking();
    }

    private void GameplayInput_OnAttackStart(object sender, System.EventArgs e)
    {
        weaponScript.StopAttacking();
    }

    private void GameplayInput_OnDodgeAction(object sender, System.EventArgs e)
    {
        if (!isDodging)
        {
            isDodging = true;
            StartCoroutine("DodgeCooldown");
            playerRigidbody.AddForce(playerRigidbody.velocity * playerStats.DodgeForce, ForceMode2D.Impulse);
        }
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
            playerRigidbody.velocity = inputVector * playerStats.MoveSpeed;
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

    IEnumerator DodgeCooldown()
    {
        yield return new WaitForSeconds(playerStats.DodgeTime);
        playerRigidbody.velocity = inputVector * playerStats.MoveSpeed;
        isDodging = false;

    }


    public bool IsRunning()
    {
        return inputVector != Vector2.zero;
    }

    public void TakeDamage(float damage)
    {
        playerStats.CurrentHealth -= damage;
    }
}