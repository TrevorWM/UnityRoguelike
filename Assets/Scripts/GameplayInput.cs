using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayInput : MonoBehaviour
{
    public event EventHandler OnDodgeAction;
    public event EventHandler OnAttackStart;
    public event EventHandler OnAttackEnd;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Gameplay.Enable();

        playerInputActions.Gameplay.Dodge.performed += Dodge_performed;
        playerInputActions.Gameplay.Attack.started += Attack_started;
        playerInputActions.Gameplay.Attack.canceled += Attack_canceled;
    }

    private void Attack_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnAttackStart?.Invoke(this, EventArgs.Empty);
    }

    private void Attack_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnAttackEnd?.Invoke(this, EventArgs.Empty);
    }

    private void Dodge_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnDodgeAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        return playerInputActions.Gameplay.Move.ReadValue<Vector2>().normalized;
    }
}
