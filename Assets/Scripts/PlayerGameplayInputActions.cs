using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerGameplayInputActions : MonoBehaviour
{
    private Player player;

    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private bool isDodging = false;
    private Vector2 inputVector;
    
    private float moveSpeed;
    private float dodgeForce;
    private float dodgeTime;

    public event EventHandler OnAttackStart;
    public event EventHandler OnAttackEnd;
    public event EventHandler OnMove;

    private void Start()
    {
        player = GetComponent<Player>();
        moveSpeed = player.moveSpeed;
        dodgeForce = player.dodgeForce;
        dodgeTime = player.dodgeTime;

        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    /*
     *  MOVE CODE
     *  ------------------------------------------------------------------------------------
     */
    public void Move(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
        
        if (!isDodging)
        {
            playerRigidbody.velocity = inputVector * moveSpeed;
            HandleMoveAnimation(context);
            OnMove?.Invoke(this, EventArgs.Empty);
        }


    }

    private void HandleMoveAnimation(InputAction.CallbackContext context)
    {
        playerAnimator.SetBool("IsRunning", true);

        if (playerRigidbody.velocity.x > 0)
        {
            playerRigidbody.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        }
        else if (playerRigidbody.velocity.x < 0)
        {
            playerRigidbody.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        if (context.canceled)
        {
            playerAnimator.SetBool("IsRunning", false);
        }
    }
    //------------------------------------------------------------------------------------


    /*
     * DODGE CODE
     * ------------------------------------------------------------------------------------
     */
    public void Dodge(InputAction.CallbackContext context)
    {
        if (context.started && !isDodging)
        {
            StartCoroutine("DodgeCooldown");
            isDodging = true;
            playerRigidbody.AddForce(playerRigidbody.velocity * dodgeForce, ForceMode2D.Impulse);
            
        }
    }

    IEnumerator DodgeCooldown()
    {
        yield return new WaitForSeconds(dodgeTime);
        playerRigidbody.velocity = inputVector * moveSpeed;
        isDodging = false;

    }
    //------------------------------------------------------------------------------------

    /*
     * ATTACK CODE
     *------------------------------------------------------------------------------------
     */
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnAttackStart?.Invoke(this, EventArgs.Empty);
        } else if (context.canceled)
        {
            OnAttackEnd?.Invoke(this, EventArgs.Empty);
        }  
    }

    //------------------------------------------------------------------------------------

}
