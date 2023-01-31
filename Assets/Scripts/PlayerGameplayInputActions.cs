using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerGameplayInputActions : MonoBehaviour
{
    [Header("Movement Values")]
    [SerializeField] private float moveSpeed = 5.0f;

    [Header("Dodge Values")]
    [SerializeField] private float dodgeForce = 1.05f;
    [SerializeField] private float dodgeTime = 0.3f;

    [Header("Weapon Equipped")]
    [SerializeField] private GameObject weapon;


    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private bool isRunning = false;
    private bool isDodging = false;
    private Vector2 inputVector;

    public event EventHandler OnAttackStart;
    public event EventHandler OnAttackEnd;
    public event EventHandler OnMove;

    private void Start()
    {
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
            //OnMove?.Invoke(this, EventArgs.Empty);
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
