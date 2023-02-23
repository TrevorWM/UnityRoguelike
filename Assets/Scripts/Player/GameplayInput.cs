using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayInput : MonoBehaviour
{
    public static event Action OnDodgeAction;
    public static event Action OnAttackStart;
    public static event Action OnAttackEnd;

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
        OnAttackEnd?.Invoke();
    }

    private void Attack_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnAttackStart?.Invoke();
    }

    private void Dodge_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnDodgeAction?.Invoke();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        return playerInputActions.Gameplay.Move.ReadValue<Vector2>().normalized;
    }
}
