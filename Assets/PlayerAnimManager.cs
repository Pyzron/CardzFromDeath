using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimManager : MonoBehaviour
{
    // Start is called before the first frame update
    Movement move;
    bool isGrounded;
    bool isDashing;
    bool isJumping;
    bool isAttacking;
    bool isDrawing;
    [SerializeField] Animator myAnim;
    [SerializeField]Vector2 direction = Vector2.zero;

    private void Awake()
    {
    }
    

    // Update is called once per frame
    void Update()
    {
        isGrounded = GetComponent<Movement>().IsGrounded();
        myAnim.SetBool("isGrounded", isGrounded);
        Activators();
        AnimSetter();
    }


    private void AnimSetter()
    {

        if(direction.x > 0 && isGrounded || direction.x < 0 && isGrounded)
        {
            myAnim.SetFloat("isRunning?", direction.x);

        }
        else
        {
            myAnim.SetFloat("isRunning?",0);
        }
        if(isDashing)
        {
            myAnim.SetBool("isDashing", true);
        }
        else
        {
            myAnim.SetBool("isDashing", false);

        }
        if(isJumping)
        {
            myAnim.SetBool("isJumping?", true);
        }
        else
        {
            myAnim.SetBool("isJumping?", false);

        }
         if(isDrawing)
        {
            myAnim.SetTrigger("isDrawing");
        }
        else
        {
            myAnim.ResetTrigger("isDrawing");

        }
        if(isAttacking)
        {
            myAnim.SetTrigger("Atk");
        }
        else
        {
            myAnim.ResetTrigger("Atk");

        }
    }
    private void Activators()
    {
        isDashing = Input.GetButtonDown("Dash");
        isJumping = Input.GetButtonDown("Jump");
        isDrawing = Input.GetButtonDown("Draw");
        isAttacking =  Input.GetButton("Fire1");
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.Normalize();
    }
}
