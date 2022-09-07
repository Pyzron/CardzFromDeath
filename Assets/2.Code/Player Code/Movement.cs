
using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField, Range(0,100f), InspectorName("Horizontal Speed")] private float _horizontalSpeed;
    [SerializeField, Range(0,100f), InspectorName("Jumping Power")] private float _jumpPower;
    [SerializeField, Range(0,10), InspectorName("Maximum jumps")] private int _maxJumps;
    [SerializeField] private int _leftJump;
    private float horizontal;
    private bool isFacingRight = true;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 12f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] bool grounded;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    //aasd
    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        
        SetInputs();

        Jump();
        if (Input.GetButtonDown("Dash") && canDash)
        {
            StartCoroutine(Dash());
        }

        Flip();
        grounded = IsGrounded();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }   
        
        SetSpeed();
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void SetInputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }
    private void SetSpeed()
    {
        rb.velocity = new Vector2(horizontal * _horizontalSpeed, rb.velocity.y);

    }
    private void Jump()
    {
        if(IsGrounded() == true)
        {
            _leftJump = _maxJumps;
        }
        if(Input.GetButtonDown("Jump") == true && _leftJump > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x , 0);
            rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _leftJump--;
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}