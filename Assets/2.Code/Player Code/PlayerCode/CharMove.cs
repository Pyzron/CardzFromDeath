using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    [SerializeField, Range(0,100f), InspectorName("Horizontal Speed")] private float _horizontalSpeed;
    [SerializeField, Range(0,100f), InspectorName("Vertical Speed")] private float _verticalSpeed;
    [SerializeField, Range(0,10), InspectorName("Maximum jumps")] private int _maxJumps;
    [SerializeField] private int _leftJump;
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField]private Vector2 _inputDirection = Vector2.zero;
    [SerializeField] private TrailRenderer tr;
    private CharInputs _charInputs;    
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    private GroundChecker _groundChecker;
    private bool _grounded;
    [SerializeField]private bool isFacingRight = true;
            private float horizontal;

    void Start()
    {
        _groundChecker = GetComponent<GroundChecker>();
        //Cache the _charInputs for future call events
        _charInputs = GetComponent<CharInputs>();
        //Calls the event that handle the movement inputs
        _charInputs.OnInputMove += OnInputMove;
        _charInputs.OnInputJump += OnInputJump; 

        _leftJump = _maxJumps;


    }

    
    void FixedUpdate()
    {
        if(isDashing == true)
        {
            return;
        }
        SetHorizontalSpeed(_inputDirection);
        
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {    
        if (isDashing)
        {
            return;
        }
        Dashy();
        Flip();
    }

    void SetHorizontalSpeed(Vector2 inputDir)
    {
        _inputDirection = inputDir;
        _rb2d.velocity = new Vector2(_horizontalSpeed * _inputDirection.x, _rb2d.velocity.y);
    }
    private void OnInputMove(object sender, Vector2 e)
    {
        SetHorizontalSpeed(e);
    }
    private void OnInputJump(object sender, bool e)
    {
        if(_groundChecker.isGrounded == true)
        {
            _leftJump = _maxJumps;
        }
        if(e == true && _leftJump > 0)
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x , 0);
            _rb2d.AddForce(Vector2.up * _verticalSpeed, ForceMode2D.Impulse);
            _leftJump--;
        }
    }
    private void Dashy()
    {
        
        if(Input.GetKeyDown(KeyCode.LeftShift) &&  canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private void Flip()
    {
        if (isFacingRight && _inputDirection.x < 0f || !isFacingRight && _inputDirection.x > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = _rb2d.gravityScale;
        _rb2d.gravityScale = 0f;
        _rb2d.velocity =  new Vector2(transform.localScale.x * dashingPower , 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        _rb2d.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }
}
