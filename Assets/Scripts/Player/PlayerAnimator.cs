using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    [SerializeField] private Player playerScript;
    
    private const string IS_RUNNING = "IsRunning";

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool(IS_RUNNING, false);
    }

    private void Update()
    {
        animator.SetBool(IS_RUNNING, playerScript.IsRunning());
    }
}
