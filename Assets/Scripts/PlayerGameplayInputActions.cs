using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGameplayInputActions : MonoBehaviour
{
    [Header("Movement Values")]
    [SerializeField] private float moveSpeed = 5.0f;

    [Header("Dodge Values")]
    [SerializeField] private float dodgeForce = 1.05f;
    [SerializeField] private float dodgeTime = 0.5f;
    
    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private bool isDodging = false;

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
        Vector2 inputVector = context.ReadValue<Vector2>();
        playerRigidbody.velocity = (inputVector * moveSpeed);
        HandleMoveAnimation(context);

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
        if(context.started && !isDodging)
        {
            isDodging = true;
            playerRigidbody.AddForce(playerRigidbody.velocity * dodgeForce, mode: ForceMode2D.Impulse);
            StartCoroutine("DodgeTimer");
        }
    }

    IEnumerator DodgeTimer()
    {
        yield return new WaitForSeconds(dodgeTime);
        playerRigidbody.velocity = playerRigidbody.velocity.normalized * moveSpeed;
        isDodging = false;
    }
    //------------------------------------------------------------------------------------

}
