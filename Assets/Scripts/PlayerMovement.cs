using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float velocity = 50;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Vector2 inputDirection;
    Animator animator;
    Transform playerTrans;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerTrans = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        
        inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        
        if (inputDirection != Vector2.zero) {
            animator.SetBool("IsRunning", true);
        } else {
            animator.SetBool("IsRunning", false);
        }
        

        if (inputDirection.x < 0) {
            playerTrans.localScale = new Vector3(-1.0f,1.0f,1.0f);

        } else if (inputDirection.x > 0) {
            playerTrans.localScale = new Vector3(1.0f,1.0f,1.0f);
        }
        
        
        
    }

    private void FixedUpdate() {
        rb.velocity = (inputDirection * velocity);
    }

}
