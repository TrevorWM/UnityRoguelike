using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Weapon Object")]
    [SerializeField] GameObject weapon;

    Rigidbody2D weaponBody;
    Animator animator;
    float animationLen;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GameObject.FindWithTag("Weapon");
        weaponBody = weapon.GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")){
            Debug.Log("Calling Attack!");
            animator.SetBool("IsAttacking", true);
        }
    }

    private void FixedUpdate() {
        
    }

    public void Attack(){
        Vector3 click = Input.mousePosition;
        Debug.Log("Attacking!");
    }

    public void StopAttack(){
        animator.SetBool("IsAttacking", false);
    }

}
