using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private IAbility[] abilities;
    private GameplayInput gameplayInput;
    private Stats playerStats;
    
    private Rigidbody2D playerRigidbody;
    private bool isDodging = false;
    private bool isAttacking = false;
    public bool autoAim = false;
    private Vector2 inputVector = Vector2.zero;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<Stats>();
        gameplayInput = GetComponent<GameplayInput>();
        abilities= GetComponents<IAbility>();

        GameplayInput.OnDodgeAction += GameplayInput_OnDodgeAction;
        GameplayInput.OnAttackStart += GameplayInput_OnAttackStart;
        GameplayInput.OnAttackEnd += GameplayInput_OnAttackEnd;
    }

    private void OnDestroy()
    {
        GameplayInput.OnDodgeAction -= GameplayInput_OnDodgeAction;
        GameplayInput.OnAttackStart -= GameplayInput_OnAttackStart;
        GameplayInput.OnAttackEnd -= GameplayInput_OnAttackEnd;
    }

    private void GameplayInput_OnAttackEnd()
    {
        abilities[0].StopAbility();
    }

    private void GameplayInput_OnAttackStart()
    {
        if (!isAttacking && !autoAim)
        {
            abilities[0].StartAbility(playerStats);
            isAttacking = true;
            StartCoroutine("AttackCooldown");
        }    
    }

    private void GameplayInput_OnDodgeAction()
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
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(1 / playerStats.AttacksPerSecond);
        isAttacking = false;
    }
}